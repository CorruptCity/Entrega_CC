using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Tools;

namespace CorruptCity.Entities.Player
{
    /*
    * Exit player if driving stops
    */
    [RequireComponent(typeof(Collider))]
    public class CarExitPoint : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private Transform exitPoint = null;

        //Variables
        private bool canExit = true;
        private List<GameObject> entitiesOnTrigger = new List<GameObject>();

        //Attributes
        public bool CanExit { get => canExit; }

        //Monobehaviour
        //Set collider config
        private void Awake() => GetComponent<Collider>().isTrigger = true;

        //Check each physics update
        private void FixedUpdate()
        {
            //Track entities if contains any entities
            if (entitiesOnTrigger.Count > 0)
            {
                //Create auxiliary list
                List<GameObject> auxiliaryList = CollectionTools.CreateAuxiliaryList(entitiesOnTrigger);

                //Track if entities on trigger are enable
                foreach (GameObject entity in auxiliaryList)
                {
                    bool canRemove = entity.activeInHierarchy == false && entitiesOnTrigger.Contains(entity);

                    //Check it is enabled and remove if not
                    if (canRemove)
                        entitiesOnTrigger.Remove(entity);
                }

                //Check again count
                canExit = auxiliaryList.Count > 0 ? false : true;
            }
            else
                canExit = true;
        }

        //Check if exit point is clear
        void OnTriggerEnter(Collider other) => CollectionTools.SaveAddToList(entitiesOnTrigger, other.gameObject);
        void OnTriggerExit(Collider other) => CollectionTools.SaveRemoveFromList(entitiesOnTrigger, other.gameObject);

        //Methods
        //Put player on exit point
        public void ExitPlayer(Transform playerTransform)
        {
            playerTransform.position = exitPoint.position;
            playerTransform.gameObject.SetActive(true);
        }
    }
}