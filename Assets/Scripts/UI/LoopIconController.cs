using System.Diagnostics;
using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.UI
{
    /*
     * Loop icon animation
     */
    [RequireComponent(typeof(AnimatedIconHandler))]
    public class LoopIconController : MonoBehaviour
    {
        //Editor variables
        [Header("Variables")]
#pragma warning disable IDE0044 // Agregar modificador de solo lectura
        [SerializeField] private float animationDelay = 0f;
        [SerializeField] private bool playIn = true;
        [SerializeField] private bool playOut = true;
#pragma warning restore IDE0044 // Agregar modificador de solo lectura

        //Variables
        private AnimatedIconHandler animatedIconHandler = null;

        //Monobehaviour
        //Take reference
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void Awake() => animatedIconHandler = GetComponent<AnimatedIconHandler>();
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados

        //Star loop
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void OnEnable() => StartCoroutine(AnimationLoop());
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados

        //Stop loop
#pragma warning disable IDE0051 // Quitar miembros privados no utilizados
        private void OnDisable() => StopAllCoroutines();
#pragma warning restore IDE0051 // Quitar miembros privados no utilizados

        //Methods
        //Loop animation
        private IEnumerator AnimationLoop()
        {
            do
            {
                //Avoid errors
                bool anyAnimation = playIn || playOut,
                    errorMessage = !anyAnimation || animationDelay <= 0;

                //Avoid errors
                if (errorMessage)
                {
                    UnityEngine.Debug.LogError("Error at " + name + ", LoopIconController, check values.");
                    yield return new WaitForEndOfFrame();
                } else
                {
                    if (playIn)
                    {
                        animatedIconHandler.PlayIn();

                        yield return new WaitForSeconds(animationDelay);
                    }

                    if (playOut)
                    {
                        animatedIconHandler.PlayOut();

                        yield return new WaitForSeconds(animationDelay);
                    }
                }
            } while (true);
        }
    }
}