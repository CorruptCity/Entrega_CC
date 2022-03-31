using UnityEngine;
using UnityEngine.Events;

namespace CorruptCity.Entities.Player.UI
{
    /*
     * Controller used to manage operations releated to UI
     */
    public class UIManagerController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Add readonly modifier
        [SerializeField] private UnityEvent pauseInEvent = null;
        [SerializeField] private UnityEvent pauseOutEvent = null;
#pragma warning restore IDE0044 // Add readonly modifier

        //Variables
        private PlayerInputActions inputActions = null;
        private bool isPause = false;

        //Monobehaviour
#pragma warning disable IDE0051 // Remove unused private members
        private void Awake()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Set variables
            inputActions = new PlayerInputActions();
            inputActions.KeysActions.Enable();
        }

#pragma warning disable IDE0051 // Remove unused private members
        private void Update()
#pragma warning restore IDE0051 // Remove unused private members
        {
            //Check input and raise
            if (Input.GetKeyDown(KeyCode.Escape))
                SwitchPauseState();
        }

        //Methods
        //Call pause switch behaviour
        public void SwitchPauseState()
        {
            //Raise responses
            if (!isPause)
            {
                isPause = true;
                pauseInEvent?.Invoke();
            }
            else if (isPause)
            {
                isPause = false;
                pauseOutEvent?.Invoke();
            }
        }
    }
}