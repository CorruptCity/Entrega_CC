using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities.Agents
{
    //Manage animations of movement
    public class AnimatorMovementController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private Animator[] animators = null;

        //Variables
        private Animator activeAnimator = null;

        //MonoBehaviour
        //Get references
        void Awake() => activeAnimator = GetActiveAnimator();

        // Update is called once per frame
        void Update()
        {
            //Check references
            if (activeAnimator == null)
                activeAnimator = GetActiveAnimator();
        }

        //Methods
        //Get reference of active animator
        private Animator GetActiveAnimator()
        {
            Animator result = null;

            //Itinerate and get active animator
            foreach (Animator animator in animators)
            {
                //Check if animator is active
                if (animator.gameObject.activeInHierarchy)
                {
                    result = animator;
                    break;
                }
            }

            return result;
        }

        //Set forward animation
        public void SetForwardAnimation()
        {
            //Local method
            //Play animation
            void PlayAnimation()
            {
                activeAnimator.SetBool("Forward", true);
                activeAnimator.SetBool("Idle", false);
                activeAnimator.SetBool("Die", false);
            }

            if (activeAnimator != null)
                PlayAnimation();
            else
            {
                GetActiveAnimator();
                if (activeAnimator != null)
                    PlayAnimation();
            }
        }

        //Set idle animation
        public void SetIdleAnimation()
        {
            //Local methods
            //Play animation
            void PlayAnimation()
            {
                activeAnimator.SetBool("Forward", false);
                activeAnimator.SetBool("Idle", true);
            }

            if (activeAnimator != null)
                PlayAnimation();
            else
            {
                GetActiveAnimator();
                if (activeAnimator != null)
                    PlayAnimation();
            }
        }

        //Set death animation
        public void SetDeathAnimation()
        {
            //Local methods
            //Play animation
            void PlayAnimation()
            {
                activeAnimator.SetBool("Forward", false);
                activeAnimator.SetBool("Idle", false);
                activeAnimator.SetBool("Die", true);
            }

            if (activeAnimator != null)
                PlayAnimation();
            else
            {
                GetActiveAnimator();
                if (activeAnimator != null)
                    PlayAnimation();
            }
        }
    }
}
