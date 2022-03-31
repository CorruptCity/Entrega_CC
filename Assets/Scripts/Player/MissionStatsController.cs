using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities.Player
{
    //Store all the stats of current mission 
    public class MissionStatsController : MonoBehaviour
    {
        //Static variables
        public static int numberBronzePlates = 0,
        numberSilverPlates = 0,
        numberGoldenPlates = 0,
        numberEthereumDrops = 0,
        missionScore = 0;

        //MonoBehaviour
        //Reset stats on mission start
        void OnEnable()
        {
            numberBronzePlates = 0;
            numberSilverPlates = 0;
            numberGoldenPlates = 0;
            numberEthereumDrops = 0;
            missionScore = 0;
        }

        //Methods
        //Send drops on mission end
        public void SendDropsToServer() => Debug.Log("Send drops to server");

        //Send mission score to server on mission end
        public void SendMissionScoreToServer() => Debug.Log("Send mission score");
    }
}