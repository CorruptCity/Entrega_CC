using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Scriptable variable used to share global floats
     */
    [CreateAssetMenu(fileName = "New_Float_variable", menuName = "Variables/Float")]
    public class ScriptableFloatVariable : AScriptableVariable<float> { }
}