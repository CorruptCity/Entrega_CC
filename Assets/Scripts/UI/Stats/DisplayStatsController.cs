using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities;
using CorruptCity.Entities.Player;
using TMPro;

namespace CorruptCity.UI
{
    //Controller used to display stats
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DisplayStatsController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private EDropType dropType = EDropType.Bronze_Plate;

        //Variables
        private TextMeshProUGUI textMeshProUGUI = null;
        private const string BRONZE_PLATE_PREFIX = " Bronze plates: ",
        SILVER_PLATE_PREFIX = " Silver plates: ",
        GOLDEN_PLATE_PREFIX = " Gold plates: ",
        ETHEREUM_PREFIX = " Ethereum: ";

        //MonoBehaviour
        //Get references
        void Awake() => textMeshProUGUI = GetComponent<TextMeshProUGUI>();

        //Keep text update
        void Update()
        {
            //Local methods
            //Take data of correct dropType
            string GetStringData()
            {
                string result = null;

                //Check drop type
                switch (dropType)
                {
                    case EDropType.Bronze_Plate:
                        result = BRONZE_PLATE_PREFIX + MissionStatsController.numberBronzePlates;
                        break;
                    case EDropType.Silver_Plate:
                        result = SILVER_PLATE_PREFIX + MissionStatsController.numberSilverPlates;
                        break;
                    case EDropType.Golden_Plate:
                        result = GOLDEN_PLATE_PREFIX + MissionStatsController.numberGoldenPlates;
                        break;
                    case EDropType.Ethereum:
                        result = ETHEREUM_PREFIX + MissionStatsController.numberEthereumDrops;
                        break;
                }

                return result;
            }

            //Code execution
            textMeshProUGUI.text = GetStringData();
        }
    }
}