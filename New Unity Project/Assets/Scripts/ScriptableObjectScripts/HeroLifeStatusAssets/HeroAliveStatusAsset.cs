using System.Collections;
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
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Update the caster hero's target hero - in the case of multiple targets
            logicTree.AddCurrent(SetTargetHero(hero));

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
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            var casterHero = hero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Update the caster hero's target hero - in the case of multiple targets
            logicTree.AddCurrent(SetTargetHero(hero));
            
            //call the hero alive status of the original caster hero (the attacker, or healer)
            hero.HeroLogic.HeroLifeStatus.CasterPreExecutionAction(basicAction,casterHero);
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(basicAction.PreExecuteActionEvents(hero));
        }
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            var casterHero = hero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Update the caster hero's target hero - in the case of multiple targets
            logicTree.AddCurrent(SetTargetHero(hero));
            
            //call the hero alive status of the original caster hero (the attacker, or healer)
            hero.HeroLogic.HeroLifeStatus.CasterPostExecutionAction(basicAction,casterHero);
        }
        
        /// <summary>
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="hero"></param>
        public override void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(basicAction.PostExecuteActionEvents(hero));
        }

        
        

      
    }
}
