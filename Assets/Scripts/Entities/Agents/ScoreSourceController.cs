using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities.Agents
{
    /*
     * This controller add to score points to global score value
     */
    public class ScoreSourceController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Agregar modificador de solo lectura
        [SerializeField] private int scoreAdd = 0;
#pragma warning restore IDE0044 // Agregar modificador de solo lectura

        //Variables
        private static int currentGlobalScore = 0;
        public static int CurrentGlobalScore { get => currentGlobalScore; }

        //Methods
        //Add score to global score
        public void Add() => currentGlobalScore = currentGlobalScore + scoreAdd;
    }
}