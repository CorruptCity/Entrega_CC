using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using CorruptCity.Variables;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace CorruptCity.Entities.Player
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Rigidbody))]
    //Control car movement with physics
    public class CarPhysicsMovementController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private float motorForce = 1000;
        [SerializeField] private float breakForce = 3000;
        [SerializeField] private float maxSteeringAngle = 30;
        [SerializeField] private float centerOfMassOffSet = -1f;
        [SerializeField] private ScriptableBoolVariable isDrivingVariable = null;
        [SerializeField] private ScriptableTransformVariable playerTransformVariable = null;
        [SerializeField] private CarExitPoint goOutPointRight = null;
        [SerializeField] private CarExitPoint goOutPointLeft = null;
        [SerializeField] private ScriptableTransformVariable playerCharacterTransform = null;
        [SerializeField] private WheelCollider frontLeftWheelCollider = null;
        [SerializeField] private WheelCollider frontRightWheelCollider = null;
        [SerializeField] private WheelCollider rearLeftWheelCollider = null;
        [SerializeField] private WheelCollider rearRightWheelCollider = null;
        [SerializeField] private Transform frontLeftWheelTransform = null;
        [SerializeField] private Transform frontRightWheelTransform = null;
        [SerializeField] private Transform rearLeftWheelTransform = null;
        [SerializeField] private Transform rearRightWheelTransform = null;
        [SerializeField] private UnityEvent deathResponse = null;
        [SerializeField] private UnityEvent startDrivingResponse = null;
        [SerializeField] private UnityEvent stopDrivingResponse = null;

        //Variables
        private const string HORIZONTAL = "Horizontal",
        VERTICAL = "Vertical";

        private float horizontalInput = 0,
        verticalInput = 0,
        currentBreakForce = 0,
        currentSteerAngle = 0,
        defaultDrag = 0;
        private bool isBreaking = false,
        isDeath = false,
        canDrive = false;

        private Rigidbody rb = null;

        //Monobehaviour
        //Gravity center lower to avoid flips
        void Awake() => rb = GetComponent<Rigidbody>();

        //Set initial components configuration
        void Start()
        {
            rb.centerOfMass += new Vector3(0, centerOfMassOffSet, 0);
            rb.isKinematic = false;
            defaultDrag = rb.drag;
        }

        //Set movement
        void FixedUpdate()
        {
            //Local methods
            //Get player input
            void GetInput()
            {
                if (!isBreaking) 
                    verticalInput = Input.GetAxis(VERTICAL);

                horizontalInput = Input.GetAxis(HORIZONTAL);
                isBreaking = Input.GetKey(KeyCode.Space);

                if (isBreaking)
                   rb.drag += 0.1f;
                else
                    rb.drag = defaultDrag;
            }
            //Set car movement
            void HandleMotor()
            {
                //Local method
                //Break movement
                void ApplyBreaking()
                {
                    frontRightWheelCollider.brakeTorque = currentBreakForce;
                    frontLeftWheelCollider.brakeTorque = currentBreakForce;
                    rearRightWheelCollider.brakeTorque = currentBreakForce;
                    rearLeftWheelCollider.brakeTorque = currentBreakForce;
                }

                frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
                frontRightWheelCollider.motorTorque = verticalInput * motorForce;
                currentBreakForce = isBreaking ? currentBreakForce : 0f;

                //Break movement
                if (isBreaking)
                    ApplyBreaking();
            }
            //Handle rotation of wheels
            void HandleSteering()
            {
                currentSteerAngle = maxSteeringAngle * horizontalInput;
                frontLeftWheelCollider.steerAngle = currentSteerAngle;
                frontRightWheelCollider.steerAngle = currentSteerAngle;
            }
            //Update visual rotation of wheels
            void UpdateWheels()
            {
                //Local method
                //Update visual of wheel
                void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
                {
                    Vector3 pos = Vector3.zero;
                    Quaternion rot = Quaternion.identity;
                    wheelCollider.GetWorldPose(out pos, out rot);
                    wheelTransform.rotation = rot;
                    wheelTransform.position = pos;
                }

                UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
                UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
                UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
                UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
            }

            //Check if can move
            if (!isDeath && isDrivingVariable.Value)
            {
                //Body
                GetInput();
                HandleMotor();
                HandleSteering();
                UpdateWheels();
            }
            else if (!isDeath && !isDrivingVariable.Value && transform.position.y < 0.15 && rb.isKinematic == false)
                rb.isKinematic = true;
        }
        void OnDisable() => isDrivingVariable.Value = false;
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
        //Block car movement, only one time
        public void Kill()
        {
            //Check status 
            if (!isDeath)
            {
                isDeath = true;

                //Only go out if its driving
                if (isDrivingVariable.Value)
                {
                    if (goOutPointRight.CanExit)
                        goOutPointRight.ExitPlayer(playerCharacterTransform.Value);
                    else
                        goOutPointLeft.ExitPlayer(playerCharacterTransform.Value);
                }

                isDrivingVariable.Value = false;
                deathResponse?.Invoke();
            }
        }

        //Switch global boolean value
        public void SwitchBoolean(CallbackContext callbackContext)
        {
            if (!isDeath)
            {
                if (callbackContext.phase == InputActionPhase.Started)
                {
                    //Make driving work
                    if (!isDrivingVariable.Value && canDrive)
                    {
                        playerCharacterTransform.Value.gameObject.SetActive(false);
                        isDrivingVariable.Value = true;
                        playerTransformVariable.Value = transform;
                        startDrivingResponse?.Invoke();
                    }
                    else if (isDrivingVariable.Value)
                    {
                        isDrivingVariable.Value = false;

                        if (goOutPointRight.CanExit)
                        {
                            stopDrivingResponse?.Invoke();
                            goOutPointRight.ExitPlayer(playerCharacterTransform.Value);
                        }
                        else if (goOutPointLeft.CanExit)
                        {
                            stopDrivingResponse?.Invoke();
                            goOutPointLeft.ExitPlayer(playerCharacterTransform.Value);
                        }
                    }
                }
            }
        }
    }
}