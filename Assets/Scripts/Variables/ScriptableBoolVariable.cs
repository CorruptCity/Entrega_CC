using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Scriptable variable used to share global booleans
     */
    [CreateAssetMenu (fileName ="New_Boolean_variable", menuName ="Variables/Boolean")]
    public class ScriptableBoolVariable : AScriptableVariable<bool> { }
}