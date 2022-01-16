using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroLifeStatusAssets
{
    [CreateAssetMenu(fileName = "HeroAlive", menuName = "Assets/HeroAliveStatus/HeroAlive")]
    public class HeroAliveStatusAsset : HeroLifeStatusAsset
    {
        /// <summary>
        /// Target HeroAlive - call hero Caster Action 
        /// After confirming target is alive, check if caster is alive
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            var casterHero = hero.HeroLogic.LastHeroTargets.TargetingHero;
            
            //call the hero alive status of the original caster hero (the attacker, or healer)
            hero.HeroLogic.HeroLifeStatus.CasterMainExecutionAction(basicAction,casterHero);
        }
        
        /// <summary>
        /// HeroAlive - basic action Execute action 
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(basicAction.ExecuteAction(hero));   
        }
        
        

      
    }
}
