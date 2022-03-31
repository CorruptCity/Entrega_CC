using UnityEngine;
using UnityEngine.Events;
using CorruptCity.General;

namespace CorruptCity.Entities.Health
{
    /*
     * Component to manage health on entities
     */
    public class HealthController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private float totalHealth = 3;
        [SerializeField] private ScriptablePlayerConfig scriptablePlayerConfig = null;
        [Header("Responsive events")]
        [SerializeField] private UnityEvent deathUnityEvent = null;
        [SerializeField] private UnityEvent damageUnityEvent = null;
        [SerializeField] private UnityEvent recoverHealthEvent = null;
        [SerializeField] private bool canLooseHealth = true;
        [SerializeField] private ShieldController shieldController = null;
#pragma warning restore IDE0044 // Add readonly modifier
        //Variables
        private float currentHealth = 0;
        private bool isDeath = false;
        public float CurrentHealth { get => currentHealth; }
        public float TotalHealth { get => totalHealth; }
        public bool CanLooseHealth { get => canLooseHealth; }

        //Monobehaviour
        //Set initial values
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
        {
            //Set player config
            if(scriptablePlayerConfig != null)
            totalHealth *= scriptablePlayerConfig.playerOfficer.lifeMultiplier;

            SetDefaultHealth();
        }
#pragma warning restore IDE0051 // Remove unused private members
        //Set values
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void OnEnable() => isDeath = false;
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados
        //Only can loose health if loose shield first
        void Update()
        {
            if (shieldController != null)
                canLooseHealth = shieldController.CurrentShield == 0;
        }

        //Methods
        //Rest life and raise related events
        public void RestHP(int lossHP)
        {
            //Check first if can loose anything
            if (canLooseHealth)
            {
                //Avoid multiple calls
                bool canDeath = currentHealth - lossHP <= 0 && !isDeath,
                    canDamage = !canDeath && !isDeath;

                //Check if entitie is gonna die
                if (canDeath)
                {
                    currentHealth = 0;
                    deathUnityEvent?.Invoke();
                    isDeath = true;
                }
                //Raise damage events
                else if (canDamage)
                {
                    currentHealth -= lossHP;
                    damageUnityEvent?.Invoke();
                }
            }
            else
            {
                damageUnityEvent?.Invoke();
                shieldController.RestShield(lossHP);
            }
        }
        //Sum life points and raise event
        public void SumHP(int sumHP)
        {
            //Check health limit
            if (currentHealth < totalHealth)
            {
                //Set current health at limit
                if (currentHealth + sumHP <= totalHealth)
                {
                    currentHealth += sumHP;
                    recoverHealthEvent?.Invoke();
                }
                else
                    currentHealth = totalHealth;
            }
        }

        //Set bool canLooseHealth 
        public void SetCanLooseHeath(bool value) => canLooseHealth = value;

        //Set current health to default
        public void SetDefaultHealth() => currentHealth = totalHealth;
    }
}