using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using CorruptCity.Entities.Player;

namespace CorruptCity.UI
{
    //Controller used to manage the drops display on chart
    [RequireComponent(typeof(PieChart))]
    public class DropsChartController : MonoBehaviour
    {
        //Variables
        private PieChart chart = null;

        //MonoBehaviour
        //Get component references
        void Awake() => chart = GetComponent<PieChart>();

        void OnEnable()
        {
            chart.ChangeValue(0, MissionStatsController.numberEthereumDrops);
            chart.ChangeValue(1, MissionStatsController.numberBronzePlates);
            chart.ChangeValue(2, MissionStatsController.numberSilverPlates);
            chart.ChangeValue(3, MissionStatsController.numberGoldenPlates);
            chart.UpdateIndicators();
        }
    }
}