using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CorruptCity.Variables;
using CorruptCity.Entities.Player;

namespace CorruptCity
{
/*
* This controller display current ammo values
*/
[RequireComponent(typeof(TextMeshProUGUI))]
    public class AmmoUIDisplay : MonoBehaviour
    {       
        //Variables
        private TextMeshProUGUI displayText = null;

        //Monobehaviour
        //Get references
        void Awake() => displayText = GetComponent<TextMeshProUGUI>();

        void Update()
        {
            string text = PlayerShootController.instance.CurrentAmmoCharge +"/"+ PlayerShootController.instance.CurrentTotalAmmo;
            displayText.text = text;
        }
    }
}