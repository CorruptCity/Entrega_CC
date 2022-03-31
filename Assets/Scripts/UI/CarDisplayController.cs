using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.General;
using UnityEngine.UI;
using CorruptCity.General.Data;

namespace CorruptCity.UI
{
    //Controller used to load, set and display vehicle information.
    public class CarDisplayController : MonoBehaviour
    {
       //Editor variables
       [Header("Variables")]
       [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
       [SerializeField] private Sprite carImage = null;
       [SerializeField] private Vehicle vehicle = null;

       //MonoBehaviour
       //Load information
       void Awake()
       {
           //Local methods
           //Load from API NFT information
           void LoadNftData() => Debug.Log("Data loading to implement");

           //Code execution
           LoadNftData();
       }

       //Methods
       //Set player config data
       public void SetVehicleData() => scriptablePlayerConfig.SetVehicle(vehicle);
       public void SetVehicleImage() => scriptablePlayerConfig.SetVehicleImage(carImage); 
    }
}