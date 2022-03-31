using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using CorruptCity.General;

namespace CorruptCity.Entities.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    /*
     * Controller used on rotation and directional movement of player on PC
     */
    public class PlayerMovementController : MonoBehaviour
    {
        //Editor variables
        [Header("Movement variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float baseMovementModifier = 5f;
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private UnityEvent playOnMovementStart = null;
        [SerializeField] private UnityEvent playOnMovementStop = null;
        [SerializeField] private AnimatorController[] animatorControllers = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private PlayerInputActions playerActions = null;
        private float turnSmoothVelocity = 0;
        private bool isMoving = false;
        //References
        private CharacterController characterController = null;
        private AnimatorController animatorMovementController = null;

        //Monobehaviour
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Get references
            characterController = GetComponent<CharacterController>();
            animatorMovementController = GetActiveAnimator();
            //Set input class
            playerActions = new PlayerInputActions();
            playerActions.MovementActions.Enable();
            //Set movement vonfig
            baseMovementModifier *= scriptablePlayerConfig.playerOfficer.movementSpeedMultiplier;
        }

#pragma warning disable IDE0051 // Remove unused private members
        private void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            bool lastMovingValue = isMoving;

            //Local methods
            //Set directional movement on character
            void DirectionalMovement()
            {
                //Get input values          
                Vector2 directionalInput = playerActions.MovementActions.HorizontalMovement.ReadValue<Vector2>().normalized;

                //Avoid references errors
                if (animatorMovementController == null)
                    animatorMovementController = GetActiveAnimator();

                //Check has enough directionalInput
                if (directionalInput.magnitude >= 0.1f)
                {
                    isMoving = true;

                    Vector3 moveDir = new Vector3(directionalInput.x, 0, directionalInput.y),
                    localMovementDirection = transform.TransformDirection(moveDir);

                    //Check distance from ground
                    if (transform.position.y >= 0.1f || transform.position.y <= -0.1f)
                        moveDir.y = -transform.position.y;

                    //Set animations
                    if (localMovementDirection.x == 0)
                    {
                        animatorMovementController.SetLeftAnimation(false);
                        animatorMovementController.SetRightAnimation(false);
                    }
                    else if (localMovementDirection.x > 0)
                        animatorMovementController.SetRightAnimation(true);
                    else
                        animatorMovementController.SetLeftAnimation(true);

                    if (localMovementDirection.z == 0)
                    {
                        animatorMovementController.SetForwardAnimation(false);
                        animatorMovementController.SetBackwardAnimation(false);
                    }
                    else if (localMovementDirection.z > 0)
                        animatorMovementController.SetForwardAnimation(true);
                    else
                        animatorMovementController.SetBackwardAnimation(true);

                    characterController.Move(moveDir * baseMovementModifier * Time.deltaTime);
                }
                else if (!animatorMovementController.IsIdle())
                {
                    isMoving = false;
                    animatorMovementController.RunIdleAnimation();
                }
            }
            //Set character looking direction
            void LookingDirection()
            {
                //Get input values
                Vector3 mousePosition = Input.mousePosition;
                //Cast raycast and check if mouse is on screen
                Ray mouseRayCast = Camera.main.ScreenPointToRay(mousePosition);

                if (Physics.Raycast(mouseRayCast, out RaycastHit raycastHit, Mathf.Infinity))
                {
                    Vector3 direction = (transform.position - raycastHit.point).normalized * -1;

                    //Set rotation with smooth
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }
            }

            //Body
            DirectionalMovement();
            LookingDirection();

            //Check last value
            bool isDifferent = lastMovingValue != isMoving;

            if (isDifferent && isMoving)
                playOnMovementStart?.Invoke();
            else if (isDifferent && !isMoving)
                playOnMovementStop?.Invoke();
        }
        //Methods
        //Itinerate animator to set only the active one
        private AnimatorController GetActiveAnimator()
        {
            AnimatorController returnValue = null;

            //Itinerate
            foreach (AnimatorController animatorController in animatorControllers)
            {
                if (animatorController.gameObject.activeInHierarchy)
                {
                    returnValue = animatorController;
                    break;
                }
            }

            return returnValue;
        }
    }
}