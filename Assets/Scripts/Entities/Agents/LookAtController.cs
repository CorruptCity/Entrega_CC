using CorruptCity.Tools.References;
using CorruptCity.Variables;
using UnityEngine;

namespace CorruptCity.Entities.Agents
{
    /*
     * Component used to track player position
     */
    public class LookAtController : MonoBehaviour
    {
        //Edito variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float turnSmoothTime = 0.1f;
        [SerializeField] private Transform targetLookAt = null;
        [SerializeField] private ScriptableTransformVariable playerReference = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private float turnSmoothVelocity = 0;
        private bool canLook = true;

        //Monbehaviour
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Check variable reference
            if (!targetLookAt && ReferencesTools.IsNullReference(playerReference))
            {
                canLook = false;
                ReferencesErrorMessages.DebugErrorMissingReference(GetType().Name, gameObject.name, "Player reference");
            }
        }
        // Update is called once per frame
#pragma warning disable IDE0051 // Remove unused private members
        void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Set character looking direction
            void LookingDirection()
            {
                //Transform to look 
                Transform targetTransform = targetLookAt ? targetLookAt 
                : !ReferencesTools.IsNullScriptableVariableReference(playerReference, out Transform variable) ? variable : null;

                //Check references values
                bool canLookAt = targetTransform;

                if (canLookAt)
                {
                    Vector3 direction = (transform.position - targetTransform.position).normalized * -1;

                    //Set rotation with smooth
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

                    transform.rotation = Quaternion.Euler(0f, angle, 0f);
                }
            }

            //Body
            if (canLook)
                LookingDirection();
        }
    }
}