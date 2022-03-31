using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities.Movement
{
    /*
     * Component used to apply forces on certain direction
     */
    [RequireComponent(typeof(Rigidbody))] [RequireComponent(typeof(Collider))]
    public class ForceController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float forceAmount = 0f;
        [SerializeField] private float dispersion = 0f;
        [SerializeField] private ForceMode forceMode = ForceMode.VelocityChange;
        [SerializeField] private EMovementDirection direction = EMovementDirection.Foward;
        [SerializeField] private bool isRelativeForce = false;
#pragma warning restore IDE0044 // Add readonly modifier
       
        //Variables
        private Rigidbody rb = null;

        //Monobehaviour
        //Get rigid to apply force
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake() => rb = GetComponent<Rigidbody>();
#pragma warning restore IDE0051 // Remove unused private members

        //Methods
        public void ApplyForce()  
        {
            //Check direction and apply force
            Vector3 forceDirection = Vector3.zero;

            switch (direction)
            {
                case EMovementDirection.Back:
                    forceDirection = Vector3.back;
                    break;

                case EMovementDirection.Down:
                    forceDirection = Vector3.down;
                    break;

                case EMovementDirection.Foward:
                    forceDirection = Vector3.forward;
                    forceDirection.x += Random.Range(-dispersion, dispersion);
                    break;

                case EMovementDirection.Left:
                    forceDirection = Vector3.left;
                    break;

                case EMovementDirection.Right:
                    forceDirection = Vector3.right;
                    break;

                case EMovementDirection.Up:
                    forceDirection = Vector3.up;
                    break;
            }

            //Set force amount
            forceDirection *= forceAmount * Time.fixedDeltaTime;

            //Check force space
            if (isRelativeForce)
                rb.AddRelativeForce(forceDirection, forceMode);
            else
                rb.AddForce(forceDirection, forceMode);
        }       
    }
}