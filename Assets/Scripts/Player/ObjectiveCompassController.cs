using CorruptCity.Entities.Agents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CorruptCity.Variables;
using CorruptCity.Tools.References;
using CorruptCity.Entities.Agents.RuntimeSet;

namespace CorruptCity.Entities.Player
{
    /*
     * Controller used to aid the nearest enemy
     */
    public class ObjectiveCompassController : MonoBehaviour
    {
        //Editor
        [Header("Variables")]
        [SerializeField] private EMissionType missionType = EMissionType.AllEnemys;
        [SerializeField] private MeshRenderer arrowRender = null;
        [SerializeField] private ScriptableTransformVariable playerTransformVariable = null;

        //Monobehaviour
        //Take nearest enemy reference and look at
        private void Update()
        {
            //Check player reference
            if (!ReferencesTools.IsNullScriptableVariableReference(playerTransformVariable, out Transform playerTransform))
            {
                //Variables
                Transform targetTransform = null;
                float shorterDistance = 1000;

                //Local methods
                //Disable/enable arrow and check if can look at something
                bool CanFaceTarget()
                {
                    bool returnValue = false;

                    //Check missions types
                    switch (missionType)
                    {
                        case EMissionType.AllEnemys:
                            returnValue = EnemyRuntimeSetRegister.runtimeSet.Count != 0;
                            break;

                        case EMissionType.FollowTarget:
                            returnValue = FollowTargetRuntimeSetRegister.runtimeSet.Count != 0;
                            break;

                        case EMissionType.KillTargets:
                            returnValue = KillTargetsRuntimeSetRegister.runtimeSet.Count != 0;
                            break;

                        case EMissionType.PickItems:
                            returnValue = PickItemsRuntimesetRegister.runtimeSet.Count != 0;
                            break;
                    }

                    //Disable/enable render
                    bool enableRenderer = returnValue && !arrowRender.enabled,
                    disableRenderer = !returnValue && arrowRender.enabled;

                    if (enableRenderer)
                        arrowRender.gameObject.SetActive(true);
                    else if (disableRenderer)
                        arrowRender.gameObject.SetActive(false);

                    return returnValue;
                }

                //Set targetTransfor
                void SetTargetTransform()
                {
                    List<Transform> runtimeSetTransform = new List<Transform>();

                    //Check missions types
                    switch (missionType)
                    {
                        case EMissionType.AllEnemys:
                            //Itinerate
                            foreach (EnemyRuntimeSetRegister enemy in EnemyRuntimeSetRegister.runtimeSet)
                                runtimeSetTransform.Add(enemy.transform);
                            break;

                        case EMissionType.FollowTarget:
                            //Itinerate
                            foreach (FollowTargetRuntimeSetRegister followTarget in FollowTargetRuntimeSetRegister.runtimeSet)
                                runtimeSetTransform.Add(followTarget.transform);
                            break;

                        case EMissionType.KillTargets:
                            //Itinerate
                            foreach (KillTargetsRuntimeSetRegister killTarget in KillTargetsRuntimeSetRegister.runtimeSet)
                                runtimeSetTransform.Add(killTarget.transform);
                            break;

                        case EMissionType.PickItems:
                            //Itinerate
                            foreach (PickItemsRuntimesetRegister pickItem in PickItemsRuntimesetRegister.runtimeSet)
                                runtimeSetTransform.Add(pickItem.transform);
                            break;
                    }

                    //Itinerate list
                    foreach (Transform target in runtimeSetTransform)
                    {
                        float distance = Vector3.Distance(playerTransform.position, target.transform.position);

                        //Check distance
                        if (distance < shorterDistance)
                        {
                            shorterDistance = distance;
                            targetTransform = target.transform;
                        }
                    }
                }

                //Check runtimeSets
                if (CanFaceTarget())
                {
                    //Set target
                    SetTargetTransform();

                    //Look target
                    transform.LookAt(new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z));
                }
            }
            else if (arrowRender.enabled)
                arrowRender.enabled = false;
        }
        //Set mission type, all enemys
        public void SetKillAllMission() => missionType = EMissionType.AllEnemys;
        //Set mission type, all enemys
        public void SetKillTargets() => missionType = EMissionType.KillTargets;

    }
    /*
    * Missions types
    */
    public enum EMissionType { KillTargets, PickItems, FollowTarget, AllEnemys }
}