using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.SkillEffectAssets
{
    [CreateAssetMenu(fileName = "SkillEffectAsset", menuName = "Assets/SkillEffectAsset")]
    public class SkillEffectAsset : ScriptableObject, ISkillEffectAsset
    {
        /// <summary>
        /// List of standard actions
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStandardActionAsset))]
        private List<ScriptableObject> standardActions = new List<ScriptableObject>();

        public List<IStandardActionAsset> StandardActions
        {
            get
            {
                var newStandardActions = new List<IStandardActionAsset>();
                foreach (var standardActionObject in standardActions)
                {
                    var standardAction = standardActionObject as IStandardActionAsset;
                    newStandardActions.Add(standardAction);
                }
                return newStandardActions;
            }
        }
        
        /// <summary>
        /// Public access to standardActions - used in unique asset creation at  LoadSkillEffect
        /// </summary>
        public List<ScriptableObject> StandardActionsScriptableObjects => standardActions;
        
        /// <summary>
        /// Subscribe all standard actions to their respective skill basic events
        /// </summary>
        /// <param name="skill"></param>
        public void SubscribeSkillEffect(ISkill skill)
        {
            foreach (var standardAction in StandardActions)
            {
                standardAction.SubscribeStandardAction(skill);
            }
        }
        
        /// <summary>
        /// Subscribe all standard actions to their respective hero basic events
        /// </summary>
        /// <param name="hero"></param>
        public void SubscribeSkillEffect(IHero hero)
        {
            foreach (var standardAction in StandardActions)
            {
                standardAction.SubscribeStandardAction(hero);
            }
        }
        
        /// <summary>
        /// Subscribe all standard actions to their respective skill basic events
        /// </summary>
        /// <param name="skill"></param>
        public void UnsubscribeSkillEffect(ISkill skill)
        {
            foreach (var standardAction in StandardActions)
            {
                standardAction.UnsubscribeStandardAction(skill);
            }
        }
        
        /// <summary>
        /// Unsubscribe all standard actions to their respective hero basic events
        /// </summary>
        /// <param name="hero"></param>
        public void UnsubscribeSkillEffect(IHero hero)
        {
            foreach (var standardAction in StandardActions)
            {
                standardAction.UnsubscribeStandardAction(hero);
            }
        }
        
        

    }
}
