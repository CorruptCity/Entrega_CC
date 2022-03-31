using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CorruptCity.Tools.References;
using CorruptCity.General;

namespace CorruptCity.UI
{
    //Display current agent ID
    public class DisplayAgentIDController : MonoBehaviour
    {
        //Editor variables
        [SerializeField] private TextMeshProUGUI agentIdTMP = null;
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;

        //Variables
        public const string AGENT_ID_PREFIX = " Agent ID: ";

        //MonoBehaviour
        //Load agent ID
        void OnEnable()
        {
            if (!ReferencesTools.IsNullReference(agentIdTMP))
                agentIdTMP.text = AGENT_ID_PREFIX + scriptablePlayerConfig.playerID;
        }
    }
}
