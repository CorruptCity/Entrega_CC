using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Patrons
{
    /*
     * This interface is use on clases with command patron and parameters
     */
    public interface IParameterCommand<T>
    {
        //Methods
        public void ExecuteCommand(T parameter);
    }
}