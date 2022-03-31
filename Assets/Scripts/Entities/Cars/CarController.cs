using CorruptCity.Entities.Player;
using CorruptCity.Variables;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace CorruptCity.Entities
{
    /*
     * This component move the car by player controllers
     */
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(CharacterController))]
    public class CarController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float speedMofifier = 0f;
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private Transform playerCharacterTransform = null;
        [SerializeField] private CarExitPoint goOutPointRight = null;
        [SerializeField] private CarExitPoint goOutPointLeft = null;
        [SerializeField] private ScriptableBoolVariable isDrivingVariable = null;
        [SerializeField] private ScriptableTransformVariable scriptableTransformVariable = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private float turnSmoothVelocity = 0;
        private PlayerInputActions playerActions = null;
        private CharacterController characterController = null;
        private bool canRotate = false,
            canMove = false,
            canDrive = false,
            isDeath = false;

        //Monobehaviour
        private void Awake()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Get references
            characterController = GetComponent<CharacterController>();
            playerActions = new PlayerInputActions();
            playerActions.KeysActions.Enable();
            playerActions.MovementActions.Enable();
            isDrivingVariable.Value = false;
        }

        // Update is called once per frame
        void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Local methods
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

            //Set movement
            void MoveCar()
            {
                //Get input values          
                Vector2 directionalInput = playerActions.MovementActions.HorizontalMovement.ReadValue<Vector2>().normalized;

                //Check has enough directionalInput
                if (directionalInput.magnitude >= 0.1f)
                {
                    Vector3 moveDir = transform.TransformDirection(new Vector3(0, 0, directionalInput.y));

                    canRotate = moveDir.z != 0;

                    //Check distance from ground
                    if (transform.position.y >= 0.1f || transform.position.y <= -0.1f)
                        moveDir.y = -transform.position.y;
                    characterController.Move(moveDir * speedMofifier * Time.deltaTime);
                }
                else
                    canRotate = false;
            }

            //TEMP SOLUTION
            canMove = isDrivingVariable.Value;

            //Body
            if (canMove)
            {
                //TEMP VALUE
                scriptableTransformVariable.Value = transform;

                MoveCar();

                if (canRotate)
                    LookingDirection();
            }
        }

        //Check if player is near enoughs to drive
        void OnTriggerEnter(Collider other)
        {
            //Check layer and set driving boolean
            if (other.gameObject.layer == 3)
                canDrive = true;
        }
        //Check if player is near enoughs to drive
        void OnTriggerExit(Collider other)
        {
            //Check layer and set driving boolean
            if (other.gameObject.layer == 3)
                canDrive = false;
        }

        //Methods
        //TEMP FUNTION
        //Switch global boolean value
        public void SwicthBoolean(CallbackContext callbackContext)
        {
            if (!isDeath)
            {
                if (callbackContext.phase == InputActionPhase.Started)
                {
                    //Make driving work
                    if (!isDrivingVariable.Value && canDrive)
                    {
                        playerCharacterTransform.gameObject.SetActive(false);
                        isDrivingVariable.Value = true;
                    }
                    else if (isDrivingVariable.Value)
                    {
                        isDrivingVariable.Value = false;

                        if (goOutPointRight.CanExit)
                            goOutPointRight.ExitPlayer(playerCharacterTransform);
                        else if (goOutPointLeft.CanExit)
                            goOutPointLeft.ExitPlayer(playerCharacterTransform);
                    }
                }
            }
        }

        //Make player go out and don't let drive again
        public void CarDeath()
        {
            canDrive = false;
            canMove = false;
            canRotate = false;
            isDeath = true;
            isDrivingVariable.Value = false;

            if (goOutPointRight.CanExit)
                goOutPointRight.ExitPlayer(playerCharacterTransform);
            else
                goOutPointLeft.ExitPlayer(playerCharacterTransform);
        }
    }
}
