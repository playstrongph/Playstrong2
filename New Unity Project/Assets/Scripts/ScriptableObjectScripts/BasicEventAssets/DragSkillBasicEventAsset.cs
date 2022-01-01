using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicEventAssets
{   
    [CreateAssetMenu(fileName = "DragSkillEvent", menuName = "Assets/BasicEvents/DragSkillEvent")]
    public class DragSkillBasicEventAsset : BasicEventAsset
    {
        /// <summary>
        /// Subscribes standard action to drag skill target event
        /// TEST - no coroutine sub-method (Delete this comment line when effective)
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public override void SubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
            skill.SkillLogic.SkillEvents.EDragSkillTarget += standardAction.StartAction;
        }
        
        /// <summary>
        /// Unsubscribes standard action to drag skill target event
        /// TEST - no coroutine sub-method (Delete this comment line when effective)
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="standardAction"></param>
        public override void UnsubscribeStandardAction(ISkill skill, IStandardActionAsset standardAction)
        {
           skill.SkillLogic.SkillEvents.EDragSkillTarget -= standardAction.StartAction;
        }
    }
}
