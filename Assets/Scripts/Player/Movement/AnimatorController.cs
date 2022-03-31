using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities
{
    /*
     * This component is used to manage animator parameters
     */
    [RequireComponent(typeof(Animator))]
    public class AnimatorController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private AnimatorParametersProfile profile = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private Animator animator = null;

        //Monobehaviour
        //Get references
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake() => animator = GetComponent<Animator>();
#pragma warning restore IDE0051 // Remove unused private members

        //Methods
        //Used to set right movement
        public void SetRightAnimation(bool value)
        {
            //Set values
            if (value)
                SetLeftAnimation(false);

            animator.SetBool(profile.RightMovement, value);
            animator.SetBool(profile.IdleParameter, false);
        }
        //Used to set left movement
        public void SetLeftAnimation(bool value)
        {
            //Set values
            if (value)
                SetRightAnimation(false);

            animator.SetBool(profile.LeftMovement, value);
            animator.SetBool(profile.IdleParameter, false);
        }
        //Used to set forward movement
        public void SetForwardAnimation(bool value)
        {
            //Set values
            if (value)
                SetBackwardAnimation(false);

            animator.SetBool(profile.ForwardMovement, value);
            animator.SetBool(profile.IdleParameter, false);
        }
        //Used to set backward movement
        public void SetBackwardAnimation(bool value)
        {
            //Set values
            if (value)
                SetForwardAnimation(false);

            animator.SetBool(profile.BackMovement, value);
            animator.SetBool(profile.IdleParameter, false);
        }
        //Set idle animation
        public void RunIdleAnimation()
        {
            animator.SetBool(profile.IdleParameter, true);
            SetRightAnimation(false);
            SetLeftAnimation(false);
            SetForwardAnimation(false);
            SetBackwardAnimation(false);
        }
        //Set death animation
        public void SetDeathAnimation(bool value)
        {
            //Check value
            if (value)
            {
                RunIdleAnimation();
                animator.SetBool(profile.IdleParameter, false);
            }
            else
                RunIdleAnimation();

            animator.SetBool(profile.DeathParameter, value);
        }

        //Return if idle is running
        public bool IsIdle() => animator.GetBool(profile.IdleParameter);
    }
}