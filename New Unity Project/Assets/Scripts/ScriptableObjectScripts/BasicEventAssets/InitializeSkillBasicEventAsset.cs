using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{   
    [CreateAssetMenu(fileName = "InitializeSkillBasicEvent", menuName = "Assets/BasicEvents/InitializeSkillBasicEvent")]
    public class InitializeSkillBasicEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes standard action to drag skill target event
        /// TEST - no coroutine sub-method (Delete this comment line when effective)
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            skill.SkillLogic.SkillEvents.EInitializeSkill += standardAction.StartAction;
            
            Debug.Log("InitializeSkill SubscribeStandardAction");
        }
        
        /// <summary>
        /// Unsubscribes standard action to drag skill target event
        /// TEST - no coroutine sub-method (Delete this comment line when effective)
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            skill.SkillLogic.SkillEvents.EInitializeSkill -= standardAction.StartAction;
        }
    }
}
