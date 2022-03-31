using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.General.Data;
using UnityEngine.UI;

namespace CorruptCity.General
{
    //Store player config on an scriptable object
    [CreateAssetMenu(fileName = "New_Player_Config", menuName = "Application/Player_Config")]
    public class ScriptablePlayerConfig : ScriptableObject
    {
        //Variables
        public Officer playerOfficer = null;
        public Vehicle playerVehicle = null;
        public Sprite nftImage = null;
        public Sprite vehicleImage = null;
        public int playerCurrentLives = 0;
        public string playerID = "0xE732782c42cf47Ae823d843b7c42EF837E68A282";
        public const int PLAYER_MAX_LIVES = 8;

        public void SetOfficer(Officer officer) => playerOfficer = officer;
        public void SetVehicle(Vehicle vehicle) => playerVehicle = vehicle;
        public void SetNFTImage(Sprite nft) => nftImage = nft;
        public void SetVehicleImage(Sprite sprite) => vehicleImage = sprite;
        public void SetCurrentPlayerLives(int lives) => playerCurrentLives = lives;
    }
}