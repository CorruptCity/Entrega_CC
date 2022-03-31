using UnityEngine;
using DG.Tweening;
using CorruptCity.Variables;
using CorruptCity.Tools.References;

namespace CorruptCity.Entities.Player
{
    /*
     * Controller used to track player position with camera
     */
    public class CamaraMovementController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float maxDistance = 0f;
        [SerializeField] private float movementTime = 0f;
        [SerializeField] private ScriptableTransformVariable playerTransformVariable = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private bool isMoving = false;

        //Monobehaviour
        //Get references
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
        {
            //Check player reference
            if (ReferencesTools.IsNullScriptableVariableReference(playerTransformVariable, out Transform _))
                ReferencesErrorMessages.DebugErrorMissingReference(GetType().Name, name, "Player transform reference");
        }
#pragma warning restore IDE0051 // Remove unused private members

        //Check if player distance is bigger than max and move camera if its necessary
#pragma warning disable IDE0051 // Remove unused private members
        private void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Check conditions            
            bool hasReference = !ReferencesTools.IsNullScriptableVariableReference(playerTransformVariable, out Transform playerTransform);
            float currentDistance = hasReference ? Vector3.Distance(transform.position, playerTransform.position) : 0;
            bool canMove = hasReference && currentDistance > maxDistance && !isMoving;

            //Check distance and move camera
            if (canMove)
            {
                isMoving = true;
#pragma warning disable IDE0090 // Use 'new(...)'
                Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
#pragma warning restore IDE0090 // Use 'new(...)'
                transform.DOMove(targetPosition, movementTime).OnComplete(() => isMoving = false);
            }
        }
    }
}