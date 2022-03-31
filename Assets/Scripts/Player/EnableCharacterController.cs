using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.General;
using CorruptCity.General.Data;

namespace CorruptCity.Entities.Player
{
    //Enable correct character based on player config
    public class EnableCharacterController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private GameObject officerGameObject = null;
        [SerializeField] private GameObject sergeantGameObject = null;
        [SerializeField] private GameObject commissarGameObject = null;

        //MonoBehaviour
        //Set active correct model
        void Awake()
        {
            //switch range cases
            switch (scriptablePlayerConfig.playerOfficer.officerRange)
            {
                case EOfficerRange.Officer:
                    officerGameObject.SetActive(true);
                    break;
                case EOfficerRange.Sergeant:
                    sergeantGameObject.SetActive(true);
                    break;
                case EOfficerRange.Commissar:
                    commissarGameObject.SetActive(true);
                    break;
            }
        }
    }
}