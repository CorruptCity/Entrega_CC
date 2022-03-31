using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Entities.Agents
{
    // Controller used to set a random render active
    public class RandomNPCRenderController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private GameObject[] renderers = null;
        [SerializeField] private UnityEvent activeRenderResponse = null;

        //MonoBehaviour
        //Set enable one render controller
        void OnEnable()
        {
            //Variables
            GameObject targetRender;

            //Local methods
            //Get target render
            void GetTargetRenderer()
            {
                int numberOfRenderers = renderers.Length - 1;

                targetRender = renderers[Random.Range(0, numberOfRenderers)];
            }

            //Manage renders
            void ManageRenderers()
            {
                //Itinerate renderers
                foreach (GameObject renderer in renderers)
                {
                    //Check if its targetRender
                    if (renderer == targetRender)
                    {
                        renderer.SetActive(true);
                        activeRenderResponse?.Invoke();
                    }
                    else
                        renderer.SetActive(false);
                }
            }

            //Code execution
            GetTargetRenderer();
            ManageRenderers();
        }
    }
}