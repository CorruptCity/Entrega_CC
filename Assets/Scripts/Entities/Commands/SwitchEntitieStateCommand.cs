using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Patrons;

namespace CorruptCity.Entities
{
    /*
     * Command used to switch states on entities 
     */
    [CreateAssetMenu(fileName ="New_Switch_Entitie_Command", menuName ="Entities/Switch_Entitie")]
    public class SwitchEntitieStateCommand : ScriptableObject, IParameterCommand<GameObject>
    {
        //Methods
        //Change state of given entitie
        public void ExecuteCommand(GameObject parameter) => parameter.SetActive(!parameter.activeInHierarchy);
    }
}