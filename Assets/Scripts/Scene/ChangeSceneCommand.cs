using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Patrons;
using UnityEngine.SceneManagement;

namespace CorruptCity.Scene
{
    [CreateAssetMenu(fileName ="New_Change_Scene_Command", menuName ="Scene/Change_Scene_Command")]
    public class ChangeSceneCommand : ScriptableObject, IParameterCommand<int>
    {
        //Methods
        //Change scene using build index
        public void ExecuteCommand(int parameter) => SceneManager.LoadScene(parameter);
    }
}
