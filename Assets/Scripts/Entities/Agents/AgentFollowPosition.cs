using UnityEngine;
using UnityEngine.AI;
using CorruptCity.Variables;
using System;
using UnityEngine.Events;

namespace CorruptCity.Entities.Agents
{
    /*
     * Component used to track position and follow it
     */
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentFollowPosition : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private Transform trackingPosition = null;
        [SerializeField] private Transform[] pathPositions = null;
        [SerializeField] private float destinationOffSet = 1f;
        [SerializeField] private ScriptableTransformVariable scriptableTransform = null;
        [SerializeField] private UnityEvent onMovementResponse = null;
        [SerializeField] private UnityEvent onDestination = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private NavMeshAgent agent = null;
        private Vector3 currentDestinationPosition = Vector3.zero;
        private bool stopMovement = false,
        canRaiseMovementResponse = true,
        canRaiseDestinationResponse = true;

        //Monobehaviour
        //Take components references
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake() => agent = GetComponent<NavMeshAgent>();
#pragma warning restore IDE0051 // Remove unused private members

        //Set initial values
        void Start() => SetNewTrackingDestinationOfArray();

        // Update is called once per frame
#pragma warning disable IDE0051 // Remove unused private members
        void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Set tracking position
            if (scriptableTransform != null && scriptableTransform.Value != null)
                trackingPosition = scriptableTransform.Value;

            //Store target destination
#pragma warning disable IDE0090 // Use 'new(...)'
            Vector3 tempDestination = new Vector3(trackingPosition.position.x, transform.position.y, trackingPosition.position.z);
#pragma warning restore IDE0090 // Use 'new(...)'

            //Check if must set destination
            bool isSameX = (int)trackingPosition.position.x == (int)transform.position.x,
                isSameZ = (int)trackingPosition.position.z == (int)trackingPosition.position.z,
                isDestinationReached = isSameX &&  isSameZ,
                startMovement = CanSetDestinationPosition() && !stopMovement && canRaiseDestinationResponse;

            //Local method
            //Check if current destination is similar to tempDestination
            bool CanSetDestinationPosition() => agent.destination != trackingPosition.position;

            //Execute destination code
            if (isDestinationReached)
            {
                //New destination
                SetNewTrackingDestinationOfArray();

                onDestination?.Invoke();
            }

            //Set destination
            if (CanSetDestinationPosition() && !stopMovement)
            {
                currentDestinationPosition = tempDestination;
                if (agent.isOnNavMesh)
                    agent.SetDestination(currentDestinationPosition);
            }
        }

        //Methods        
        //Change current destination to a new one
        public void ChangeTargetDestionation(Transform newDestination) => trackingPosition = newDestination;

        //Set movement values for
        public void SetMovementValue(bool value) => stopMovement = value;

        //Set new tracking destination of positions array
        private void SetNewTrackingDestinationOfArray()
        {
            //Avoid errors
            bool avoidArrayErrors = pathPositions.Length > 1;

            //Check path options for
            if (avoidArrayErrors)
            {
                //New position set
                bool isNewPosition = false;

                //Set random position
                do
                {
                    //New position
                    Transform newPosition = pathPositions[UnityEngine.Random.Range(0, pathPositions.Length - 1)];

                    //Change positions 
                    if (newPosition != trackingPosition)
                    {
                        trackingPosition = newPosition;
                        isNewPosition = true;
                    }
                } while (!isNewPosition);
            }
        }
    }
}