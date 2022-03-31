using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Patrons;

namespace CorruptCity.General
{
    /*
     * Command used to close aplication
     */
    [CreateAssetMenu(fileName = "New_Close_Application_Command", menuName = "Application/Close_Application_Command")]
    public class CloseApplicationCommand : ScriptableObject, ICommand
    {
        //Methods
        //Execute close application command
        public void ExecuteCommand() => Application.Quit();
    }
}