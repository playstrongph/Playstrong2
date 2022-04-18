using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.ActionTargetAssets
{
    [CreateAssetMenu(fileName = "StatusEffectCasterHero", menuName = "Assets/ActionTargets/StatusEffectCasterHero")]
    public class StatusEffectCasterHeroAsset : ActionHeroesAsset
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
            var statusEffectActionAsset = standardActionAsset as IStatusEffectActionAsset;

            var statusEffectCasterHero = statusEffectActionAsset?.StatusEffectCasterHero;

            var actionTargets = new List<IHero>{statusEffectCasterHero};

            return actionTargets;
        }
        
        public override List<IHero> GetEventSubscribers(IHero hero)
        {
            var actionTargets = new List<IHero> {};
            
            Debug.Log("Target Hero can not be an event subscriber");
            
            return actionTargets;
            
        }
        
    }
}
