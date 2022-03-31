using UnityEngine;

namespace CorruptCity.Variables
{
    /*
     * Variable used on transform references
     */
    [CreateAssetMenu(fileName ="New_Transform_Variable", menuName ="Variables/Transform")]
    public class ScriptableTransformVariable : AScriptableVariable<Transform> { }
}