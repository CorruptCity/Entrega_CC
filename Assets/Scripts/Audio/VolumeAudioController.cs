using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Variables;

namespace CorruptCity.Audio
{
    public class VolumeAudioController : MonoBehaviour
    {
        //Editor variables
       [Header("Variables")]
       [SerializeField] private VolumeLink[] links = null;

       //MonoBehaviour
       //Keep audio source volume same as volume float
       void Update()
       {
           //Itinerate links and set volume
           foreach (VolumeLink link in links)
           {
               //Itinerate audio sources
               foreach (AudioSource source in link.AudioSources)
                   source.volume = link.Volume.Value;
           }
       }
    }
}