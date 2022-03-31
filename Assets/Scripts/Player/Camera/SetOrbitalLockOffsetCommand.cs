using UnityEngine;
using CorruptCity.Patrons;
using Cinemachine;

namespace CorruptCity.Entities.Player
{
    /// <summary>
    // Command used to set orbital lock off set position
    /// </summary>
    [CreateAssetMenu(fileName = "New_SetOrbitalLockOffset_Command", menuName = "Commands/SetOrbitalLockOffset")]
    public class SetOrbitalLockOffsetCommand : ScriptableObject, IParameterCommand<CinemachineVirtualCamera>
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private Vector3 offset = Vector3.zero;

        //Methods
        //Set on execution command offset 
        public void ExecuteCommand(CinemachineVirtualCamera parameter)
        {
            
        }
    }
}