using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using CorruptCity.Variables;

namespace CorruptCity.Entities.Player
{
    /*
    * Controller to set follow target on cinemachine at current player position
    */
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class CameraFollowPlayerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ScriptableTransformVariable playerTransformVariable = null;

        //Variables
        private CinemachineVirtualCamera cinemachineVirtualCamera = null;

        //Monobehaviour
        //Get references
        void Awake() => cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();

        void Update() => cinemachineVirtualCamera.Follow = playerTransformVariable.Value;
    }
}