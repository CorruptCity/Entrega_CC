using UnityEngine;
using CorruptCity.Patrons;

namespace CorruptCity.General
{

    [CreateAssetMenu(fileName = "New_Set_Transform_Command", menuName = "Commands/Set_Transform")]
    public class SetTransformAssetCommand : ScriptableObject, IParameterCommand<Transform>
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private UnityEngine.Vector3 targetPosition = UnityEngine.Vector3.zero;
        [SerializeField] private UnityEngine.Vector3 targetRotation = UnityEngine.Vector3.zero;
        [SerializeField] private bool setYPosition = false;
        [SerializeField] private bool setXRotation = false;
        [SerializeField] private bool setYRotation = false;
        [SerializeField] private bool setZRotation = false;
        //IParameterCommand
        //Set transform parameters
        public void ExecuteCommand(Transform parameter)
        {
            if (setYPosition)
                parameter.position = new Vector3(parameter.position.x, targetPosition.y, parameter.position.z);

            //Store temp rotation value
            Vector3 tempRotation = targetRotation;

            //Set custom or parameter values
            if (!setXRotation)
                tempRotation = new Vector3(parameter.eulerAngles.x, tempRotation.y, tempRotation.z);
            if (!setYRotation)
                tempRotation = new Vector3(tempRotation.x, parameter.eulerAngles.y, tempRotation.z);
            if (!setZRotation)
                tempRotation = new Vector3(tempRotation.x, tempRotation.y, parameter.eulerAngles.z);           

            parameter.rotation = Quaternion.Euler(tempRotation);
        }
    }
}