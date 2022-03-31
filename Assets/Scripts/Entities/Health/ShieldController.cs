using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities.Health
{
    /*
    * Manage player shield, avoid heath damage
    */
    [RequireComponent(typeof(HealthController))]
    public class ShieldController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private int maxShield = 3;
        [SerializeField] private int currentShield = 0;

        //Attributes
        public int CurrentShield { get => currentShield; }
        public int MaxShield{ get => maxShield; }

        //Methods
        //Add shield value
        public void AddShield(int shieldAmount)
        {
            //Check limits
            if (maxShield >= currentShield + shieldAmount)
                currentShield += shieldAmount;
            else
                currentShield = maxShield;
        }
        //Rest shield value
        public void RestShield(int shieldAmount)
        {
            //Check limits
            if (0 <= currentShield - shieldAmount)
                currentShield -= shieldAmount;
            else
                currentShield = 0;
        }
    }
}
