using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities
{
    [CreateAssetMenu(fileName ="Player_Movement_Animator_Parameters", menuName = "Player/Movement/AnimatorParameters")]    
    public class AnimatorParametersProfile : ScriptableObject
    {
        //Editor variables
        [Header("Parameters names")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private string forwardMovement = null;
        [SerializeField] private string backMovement = null;
        [SerializeField] private string leftMovement = null;
        [SerializeField] private string rightMovement = null;
        [SerializeField] private string idleParameter = null;
        [SerializeField] private string deathParameter = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Attributes
        public string ForwardMovement { get => forwardMovement; }
        public string BackMovement { get => backMovement; }
        public string LeftMovement { get => leftMovement; }
        public string RightMovement { get => rightMovement; }
        public string IdleParameter { get => idleParameter; }
        public string DeathParameter { get => deathParameter; }
    }
}