using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//TEMP, DO IT BETTER
public class CarShooting : MonoBehaviour
{
    //Editor variables
    [Header("Variables")]
    [SerializeField] private UnityEvent shootToEnemy = null;
    [SerializeField] private UnityEvent stopShooting = null;
    [SerializeField] private Transform shootingPoint = null;
    [SerializeField] private UnityEngine.Vector3 shootingOffSet = UnityEngine.Vector3.zero;
    [SerializeField] private bool smoothShoot = false;
    [SerializeField] private float turnSmoothTime = 0.1f;

    //Variables
    readonly List<GameObject> targets = new List<GameObject>();
    private float turnSmoothVelocity = 0;

    bool dontShoot = true;

    private void Update()
    {
        //Local methods
        //Remove empty targets from list
        void RemoveFromTargets()
        {
            List<GameObject> toRemove = new List<GameObject>();

            foreach (GameObject target in targets)
                if (!target.activeInHierarchy)
                    toRemove.Add(target);

            foreach (GameObject tempObj in toRemove)
                targets.Remove(tempObj);
        }

        //Check if must stop shooting loop
        void CheckStopShooting()
        {
            bool mustStop = targets.Count == 0 && dontShoot == false;

            if (mustStop)
            {
                dontShoot = true;
                stopShooting?.Invoke();
            }
        }

        //Rotation to nearest target
        void LookingDirection()
        {
            //Itinerate targets to fins nearest
            Transform nearestTarget = null;
            float shorterDistance = 10000f;

            foreach (GameObject target in targets)
            {
                float distanceToTarget = UnityEngine.Vector3.Distance(target.transform.position, transform.position);

                //Check distance
                if (shorterDistance > distanceToTarget)
                    nearestTarget = target.transform;
            }

            //Avoid null references
            if (nearestTarget != null)
            {
                UnityEngine.Vector3 direction = (transform.position - nearestTarget.transform.position).normalized * -1;

                //Set rotation with smooth
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                transform.rotation = UnityEngine.Quaternion.Euler(0f, angle, 0f);

                //Dot variables
                UnityEngine.Vector3 forward = transform.TransformDirection(UnityEngine.Vector3.forward);
                UnityEngine.Vector3 toOther = nearestTarget.position - transform.position;

                if (UnityEngine.Vector3.Dot(forward, toOther) > 0.85f)
                    shootToEnemy?.Invoke();
            }
        }

        //Code execution
        RemoveFromTargets();
        CheckStopShooting();

        //Check if can make smooth looking
        if (smoothShoot)
            LookingDirection();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            //Check if smooth look at is enabled
            if (!smoothShoot)
            {
                //Put looking point
                UnityEngine.Vector3 lookingPoint = other.transform.position + shootingOffSet;

                shootingPoint.LookAt(lookingPoint);
                shootToEnemy?.Invoke();
            }

            if (!targets.Contains(other.gameObject))
            {
                targets.Add(other.gameObject);
                dontShoot = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            stopShooting?.Invoke();

            if (targets.Contains(other.gameObject))
                targets.Remove(other.gameObject);
        }
    }
}
