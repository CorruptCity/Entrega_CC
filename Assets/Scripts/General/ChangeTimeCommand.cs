using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;
using CorruptCity.Patrons;

namespace CorruptCity.General
{
    [CreateAssetMenu(fileName = "New_Change_Time_Command", menuName = "Application/Time_Scale_Command")]
    public class ChangeTimeCommand : ScriptableObject, IParameterCommand<float>
    {
        //IParameterCommand
        //Set time to value
        public void ExecuteCommand(float parameter) => Time.timeScale = parameter;
    }
}