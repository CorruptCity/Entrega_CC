using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Entities.Player;

namespace CorruptCity.Entities
{
    //Drop controller, used to collect drops
    public class DropController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private EDropType dropType = EDropType.Bronze_Plate;

        //Send to mission stats drop
        public void SendDrop()
        {
            //Check dropType
            switch (dropType)
            {
                case EDropType.Bronze_Plate:
                    MissionStatsController.numberBronzePlates++;
                    break;
                case EDropType.Silver_Plate:
                    MissionStatsController.numberSilverPlates++;
                    break;
                case EDropType.Golden_Plate:
                    MissionStatsController.numberGoldenPlates++;
                    break;
                case EDropType.Ethereum:
                    MissionStatsController.numberEthereumDrops++;
                    break;
            }
        }
    }
}