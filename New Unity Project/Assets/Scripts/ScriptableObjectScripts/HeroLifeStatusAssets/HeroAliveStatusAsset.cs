using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    public class HeroAliveStatusAsset : HeroLifeStatusAsset
    {
        /// <summary>
        /// Target HeroAlive - call hero Caster Action
        /// Target HeroDead - Do nothing
        /// After confirming target is alive, check if caster is alive
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void TargetAction(IBasicActionAsset basicAction, IHero hero)
        {
            //TODO: hero.herologic.heroAttributes.lifestatus.CasterAction
        }
        
        /// <summary>
        /// HeroAlive - basic action Execute action
        /// HeroDead - Do nothing
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void CasterAction(IBasicActionAsset basicAction, IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(basicAction.ExecuteAction(hero));   
        }

      
    }
}
