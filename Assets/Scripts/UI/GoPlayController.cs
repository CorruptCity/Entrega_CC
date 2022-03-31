using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.General;
using UnityEngine.SceneManagement;

namespace CorruptCity.UI
{
    //Controller used to star gameplay
    public class GoPlayController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private int sceneIndex = 0;

        //Methods
        //Change scene if player has enoughs lives
        public void PlayMission()
        {
            if (scriptablePlayerConfig.playerCurrentLives > 0)
            {
                scriptablePlayerConfig.playerCurrentLives--;
                Debug.LogWarning("Send information to server");
                SceneManager.LoadScene(sceneIndex);
            }
        }
    }
}