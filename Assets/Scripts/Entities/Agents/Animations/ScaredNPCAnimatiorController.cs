using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Entities.Agents
{
    /*
    * Set random animation on npc of afraid
    */
    [RequireComponent(typeof(Animator))]
    public class ScaredNPCAnimatiorController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private UnityEvent dieUnityEvent = null;

        //Variables
        private Animator animator = null;

        //Monobehaviour
        //Get references and set initial values
        void Awake()
        {
            animator = GetComponent<Animator>();
            animator.SetFloat("AfraidAnimation", Random.Range(0, 2));
        }

        //Methods
        //NPC die animation
        public void KillNPC()
        {
            //Avoid errors
            if (!animator.GetBool("Die"))
            {
                animator.SetBool("Die", true);
                dieUnityEvent?.Invoke();
            }
        }
    }
}