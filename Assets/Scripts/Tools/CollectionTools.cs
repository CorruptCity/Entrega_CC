using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorruptCity.Tools
{
    /*
     * Static class used on generic operations related to collections
     */
    public static class CollectionTools
    {
        //Search coincidences inside an array
        public static bool ContainsObject<T>(T[] array, T targetObject)
        {
            bool returnValue = false;

            //Search for coincidences
            foreach (T value in array)
                if (value.Equals(targetObject))
                {
                    returnValue = true;
                    break;
                }

            return returnValue;
        }
        //Create auxiliary list
        public static List<T> CreateAuxiliaryList<T>(List<T> list)
        {
            //Return value
            List<T> result = new List<T>();

            //Itinerate list and replicate
            foreach (T value in list)
                result.Add(value);

            return result;
        }
        //Save object add to list
        public static void SaveAddToList<T>(List<T> list, T addValue)
        {
            //Check if contains and add to list
            if (!list.Contains(addValue))
                list.Add(addValue);
        }
        //Save remove from list
        public static void SaveRemoveFromList<T>(List<T> list, T removeValue)
        {
            //Check if contains and remove from list
            if (list.Contains(removeValue))
                list.Remove(removeValue);
        }
    }
}