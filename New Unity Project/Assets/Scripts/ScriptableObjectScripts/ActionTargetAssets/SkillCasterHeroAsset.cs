using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "SkillCasterHero", menuName = "Assets/ActionTargets/SkillCasterHero")]
    public class SkillCasterHeroAsset : ActionTargetAsset
    {
        /// <summary>
        /// Returns the hero's targeted hero
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override List<IHero> ActionTargets(IHero hero)
        {
            var actionTargets = new List<IHero>();

            
            
            return actionTargets;
        }
        
        
    }
}
