using System.Net.Mime;
using UnityEngine;
using CorruptCity.General;
using UnityEngine.UI;
using CorruptCity.General.Data;

namespace CorruptCity.UI
{
    //Controller used to load, set and display global officer information
    public class OfficerDisplayController : MonoBehaviour
    {
        //Editor variable
        [Header("Variables")]
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [SerializeField] private Image nftImage = null;
        [SerializeField] private Officer officer = null;

        //Monobehaviour
        //Load nft information
        void Awake()
        {
            //local method
            //Load from API NFT information
            void LoadNftData() => Debug.LogWarning("Data loading to implement");

            LoadNftData();
        }

        //Methods
        //Set to player config the data
        public void SetOfficerData() => scriptablePlayerConfig.SetOfficer(officer);
        public void SetNftImage() => scriptablePlayerConfig.SetNFTImage(nftImage.sprite);
    }
}