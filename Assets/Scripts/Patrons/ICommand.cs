using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Patrons
{
    /*
     * Interface used to execute commands
     */
    public interface ICommand
    {
        //Methods
        //Execute command
        public void ExecuteCommand();
    }
}
