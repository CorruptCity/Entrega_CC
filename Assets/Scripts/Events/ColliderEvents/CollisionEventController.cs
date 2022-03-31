using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Events
{
    /*
     * This component raise events on collider collisions call backs
     */
    public class CollisionEventController : AColliderEventTrigger
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private LayersResponse[] collisionEnterLayerResponse;

        //Monobehaviour
        //Raise events on collision enter callbacks
        //Check layer responses & raise related events
        private void OnCollisionEnter(Collision collision) => CheckResponses(collisionEnterLayerResponse, collision.gameObject.layer);
    }
}