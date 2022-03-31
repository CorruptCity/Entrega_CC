using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CorruptCity.Variables;
namespace CorruptCity.UI
{
    [RequireComponent(typeof(Slider))]
    //Keep the correct size of bar content
    public class ShieldContentController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
        [SerializeField] private ShieldVariable shieldVariable = null;

        private float widthHealthRelation = 0f;
        private Slider slider = null;

        //MonoBehaviour
        //Get references 
        void Awake() => slider = GetComponent<Slider>();

        //Set values
        //Set width health relation
        void Start()
        {
            slider.minValue = 0;
            slider.maxValue = shieldVariable.Value.MaxShield;
        }

        //Keep size and position
        void Update() => slider.value = shieldVariable.Value.CurrentShield;
    }
}