using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Entities.Agents.RuntimeSet
{
    //Base class used to register entities on runtimeSets
    public abstract class ARuntimeSetRegister<T> : MonoBehaviour
    {       
        //Variables
        public static readonly List<ARuntimeSetRegister<T>> runtimeSet = new List<ARuntimeSetRegister<T>>();

        //Monobehaviour
        //Add and remove reference from runtimeset
        private void OnEnable() => runtimeSet.Add(this);
        private void OnDisable() => runtimeSet.Remove(this);
    }

}