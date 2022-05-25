using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "SkillCasterHero", menuName = "Assets/ActionTargets/SkillCasterHero")]
    public class SkillCasterHeroAsset : ActionHeroesAsset
    {
        /// <summary>
        /// Returns the status effect target hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardActionAsset"></param>
        /// <returns></returns>
        public override List<IHero> GetActionHeroes(IHero casterHero,IHero targetHero, IStandardActionAsset standardActionAsset)
        {
            var skillActionAsset = standardActionAsset as ISkillActionAsset;

            var skillCasterHero = skillActionAsset?.SkillCasterHero;

            var actionTargets = new List<IHero>{skillCasterHero};

            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero hero)
        {
            var actionTargets = new List<IHero> {};
            
            Debug.Log("Skill Caster Hero can not be an event subscriber");
            
            return actionTargets;
            
        }
        
        
    }
}
