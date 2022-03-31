using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Scene
{
    //*Component used to enable enemies post death
    public class ResetEnemies : MonoBehaviour
    {
        //Editor variables
        [Header("References")]
        [SerializeField] private GameObject[] enemies = null;

        //Monobehaviour
        //Set enable all enemies
        void OnEnable()
        {
            foreach (GameObject enemy in enemies)
                enemy.SetActive(true);
        }
    }
}
