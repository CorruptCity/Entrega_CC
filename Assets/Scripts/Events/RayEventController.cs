using CorruptCity.Tools.References;
using CorruptCity.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Events
{
    /*
     * Component used to raise events on different raycast callbacks situations
     */
    public class RayEventController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private int[] targetLayers = null;
        [SerializeField] private float distanceCallback = 3f;
        [SerializeField] private bool infiniteCast = false;
        [SerializeField] private Transform targetTransform = null;
        [SerializeField] private ScriptableTransformVariable transformVariable = null;
        [Tooltip("All the events will be raise only one time when condition is TRUE, after it, must reset before raise event again")]
        [SerializeField] private UnityEvent onDistanceUnityEvent = null;
        [SerializeField] private UnityEvent outOfDistanceUnityEvent = null;
        [SerializeField] private UnityEvent onViewUnityEvent = null;
        [SerializeField] private UnityEvent outViewUnityEvent = null;
        [SerializeField] private UnityEvent onDistanceAndViewUnityEvent = null;
        [SerializeField] private UnityEvent outDistanceAndViewUnityEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private bool onDistance = false,
            onView = false,
            onDistanceAndView = false;
        private float castDistance = 0f;

        //Monobehaviour
#pragma warning disable IDE0051 // Remove unused private members
        //Set distance
        private void Awake() => castDistance = infiniteCast ? Mathf.Infinity : distanceCallback;
#pragma warning restore IDE0051 // Remove unused private members

        //Used to cast raycast and get callbacks
#pragma warning disable IDE0051 // Remove unused private members
        private void FixedUpdate()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Local methods
            //Raise distance events and switch value
            void RaiseOnDistanceEvents(bool newValue)
            {
                //Check if value is different
                bool raiseOnDistanceEvent = newValue != onDistance && newValue,
                    raiseOutDistanceEvent = newValue != onDistance && !newValue;

                //Raise events
                if (raiseOnDistanceEvent)
                    onDistanceUnityEvent?.Invoke();
                else if (raiseOutDistanceEvent)
                    outOfDistanceUnityEvent?.Invoke();

                //Switch value
                if (raiseOnDistanceEvent || raiseOutDistanceEvent)
                    onDistance = newValue;
            }
            //Raise view events and switch value
            void RaiseOnViewEvents(bool newValue)
            {
                //Check if value is different
                bool raiseOnViewEvent = newValue != onView && newValue,
                    raiseOutViewEvent = newValue != onView && !newValue;

                //Raise events
                if (raiseOnViewEvent)
                    onViewUnityEvent?.Invoke();
                else if (raiseOutViewEvent)
                    outViewUnityEvent?.Invoke();

                //Switch value
                if (raiseOnViewEvent || raiseOutViewEvent)
                    onView = newValue;
            }
            //Raise view and distance events and switch value
            void RaiseOnViewAndDistanceEvents()
            {
                //Check values
                bool raiseOnViewAndDistanceEvent = onView && onDistance && !onDistanceAndView,
                    isOut = !onView || !onDistance,
                    raiseOutViewAndDistanceEvent = isOut && onDistanceAndView;

                //Raise events
                if (raiseOnViewAndDistanceEvent)
                {
                    onDistanceAndView = true;
                    onDistanceAndViewUnityEvent?.Invoke();
                }
                else if (raiseOutViewAndDistanceEvent)
                {
                    onDistanceAndView = false;
                    outDistanceAndViewUnityEvent?.Invoke();
                }
            }
            //Check layers and raise on view event
            void CheckHitLayer(int hitLayer)
            {
                bool isTarget = false;
                //Itenerate layers
                foreach (int layer in targetLayers)
                {
                    //Check layer
                    if (layer == hitLayer)
                    {
                        isTarget = true;
                        break;
                    }
                }

                //Raise events if its necessary
                if (isTarget)
                    RaiseOnViewEvents(true);
                else
                    RaiseOnViewEvents(false);
            }
            //Cast ray if there is target
            bool TargetRaycast()
            {
                //Return if can cast
                bool returnValue = false;
                //Set transform reference
                Transform tempTransform;

                //Local methods
                //Cast raycast and set values
                void CastRay()
                {
                    returnValue = true;

                    //Check if can raise distance events
                    RaiseOnDistanceEvents(Vector3.Distance(transform.position, tempTransform.position) <= distanceCallback);

                    Vector3 direction = (transform.position - tempTransform.position).normalized;

                    //Check view
                    if (Physics.Raycast(transform.position, direction * -1, out RaycastHit raycastHit, castDistance))
                    {
                        CheckHitLayer(raycastHit.transform.gameObject.layer);
                        RaiseOnViewAndDistanceEvents();
                    }
                    else
                        RaiseOnViewEvents(false);
                }

                //Body
                //Execute ray
                if (targetTransform != null)
                {
                    tempTransform = targetTransform;
                    CastRay();
                }
                else if (!ReferencesTools.IsNullScriptableVariableReference(transformVariable, out Transform variable))
                {
                    tempTransform = variable;
                    CastRay();
                }

                return returnValue;
            }
            //Cast ray if there inst target
            void NonTargetRaycast()
            {
                //Cast
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit raycastHit, castDistance))
                {
                    //Check distance
                    RaiseOnDistanceEvents(raycastHit.distance <= distanceCallback);

                    CheckHitLayer(raycastHit.transform.gameObject.layer);
                }
                else
                {
                    RaiseOnDistanceEvents(false);
                    RaiseOnViewEvents(false);
                }
            }

            //Body
            if (!TargetRaycast())
                NonTargetRaycast();
        }
    }
}