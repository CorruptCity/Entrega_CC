using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CorruptCity.Tools.References;
using CorruptCity.General;
using UnityEngine.UI;
using CorruptCity.General.Data;

namespace CorruptCity.UI
{
    //Controller used to display player config
    public class DisplayPlayerConfigController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private Image displayImage = null;
        [SerializeField] private TextMeshProUGUI badgeNumberTMP = null;
        [SerializeField] private TextMeshProUGUI rangeTMP = null;
        [SerializeField] private TextMeshProUGUI weaponTMP = null;
        [SerializeField] private TextMeshProUGUI lifeTMP = null;
        [SerializeField] private TextMeshProUGUI speedTMP = null;

        //Variables
        private const string BADGE_NUMBER_PREFIX = " Badge number: ",
        RANGE_PREFIX = " Range: ",
        WEAPON_PREFIX = " Weapon: ",
        LIFE_PREFIX = " Life: x",
        SPEED_PREFIX = " Speed: x";

        //Monobehaviour
        //Keep update all the information to display
        void Update()
        {
            #region Avoid errors of missing references
            if (!ReferencesTools.IsNullReference(scriptablePlayerConfig))
            {
                //Officer to display
                Officer officer = scriptablePlayerConfig.playerOfficer;

                if (!ReferencesTools.IsNullReference(badgeNumberTMP))
                    badgeNumberTMP.text = BADGE_NUMBER_PREFIX + officer.BadgeNumber;

                if (!ReferencesTools.IsNullReference(rangeTMP))
                    rangeTMP.text = RANGE_PREFIX + officer.officerRange;

                //Local method
                //Get text from enum
                string WeaponName(EWeapon weaponType)
                {
                    string returnValue = null;

                    //Switch cases
                    switch (weaponType)
                    {
                        case EWeapon.GrenadeLauncher:
                            returnValue = "Grenade launcher";
                            break;
                        case EWeapon.Gun:
                            returnValue = "Gun";
                            break;
                        case EWeapon.MachineGun:
                            returnValue = "Machine gun";
                            break;
                        case EWeapon.Rifle:
                            returnValue = "Rifle";
                            break;
                        case EWeapon.RPG:
                            returnValue = "RPG";
                            break;
                    }

                    return returnValue;
                }

                if (!ReferencesTools.IsNullReference(weaponTMP))
                    weaponTMP.text = WEAPON_PREFIX + WeaponName(officer.weapon);

                if (!ReferencesTools.IsNullReference(lifeTMP))
                    lifeTMP.text = LIFE_PREFIX + officer.lifeMultiplier.ToString();

                if (!ReferencesTools.IsNullReference(speedTMP))
                    speedTMP.text = SPEED_PREFIX + officer.movementSpeedMultiplier.ToString();

                if(!ReferencesTools.IsNullReference(displayImage))
                    displayImage.sprite = scriptablePlayerConfig.nftImage;
            }


            #endregion
        }
    }
}