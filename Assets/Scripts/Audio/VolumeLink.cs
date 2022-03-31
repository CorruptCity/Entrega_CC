using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Variables;
using System;

namespace CorruptCity.Audio
{
    //Store audio source-volume variable references
    [Serializable]
    public struct VolumeLink
    {
        //Editor variables
        [Header("Variables")]
        [TextArea(3, 7)]
        [SerializeField] private string name;
        [SerializeField] private ScriptableFloatVariable volumeVariable;
        [SerializeField] private AudioSource[] audioSources;

        //Attributes
        public ScriptableFloatVariable Volume { get => volumeVariable; }
        public AudioSource[] AudioSources { get => audioSources; }
    }
}
