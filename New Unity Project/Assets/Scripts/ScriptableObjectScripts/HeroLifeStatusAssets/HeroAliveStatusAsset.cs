using System.Collections;
using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //Check if the caster is still alive
            targetHero.HeroLogic.HeroLifeStatus.CasterMainExecutionAction(basicAction,casterHero,targetHero);
        }

        /// <summary>
        /// Check Inability and call basic action 
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            casterHero.HeroLogic.HeroInabilityStatus.ExecuteBasicAction(basicAction,casterHero,targetHero);
        }
        
        
        //TEST 11 Apr 2022
        public override void TargetStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        {
            targetHero.HeroLogic.HeroLifeStatus.CasterStandardAction(standardAction,casterHero,targetHero);
        }
        
        public override void CasterStandardAction(IStandardActionAsset standardAction, IHero casterHero,IHero targetHero)
        {
            //TODO: Check inability status
            casterHero.HeroLogic.HeroInabilityStatus.ExecuteStandardAction(standardAction,casterHero,targetHero);
        }
        
        
        //TEST - END 11 Apr 2022




        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //call the hero alive status of the original caster hero (the attacker, or healer)
            targetHero.HeroLogic.HeroLifeStatus.CasterPreExecutionAction(basicAction,casterHero,targetHero);
        }
        
        /// <summary>
        /// Check Inability and call basic action events
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //original
            //logicTree.AddCurrent(basicAction.CallPreBasicActionEvents(casterHero,targetHero));
                
            // Calls pre basic action events if caster has no Inabilities
            casterHero.HeroLogic.HeroInabilityStatus.CallPreBasicActionEvents(basicAction,casterHero,targetHero);
        }
        
        /// <summary>
        /// After confirming target is alive, check if caster is alive
        /// before implementing the basic action's post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //call the hero alive status of the original caster hero (the attacker, or healer)
            targetHero.HeroLogic.HeroLifeStatus.CasterPostExecutionAction(basicAction,casterHero,targetHero);
        }
        
        /// <summary>
        /// Check Inability and call basic action events
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //Original
            //logicTree.AddCurrent(basicAction.CallPostBasicActionEvents(casterHero,targetHero));
            
            // Calls post basic action events if caster has no Inabilities
            casterHero.HeroLogic.HeroInabilityStatus.CallPostBasicActionEvents(basicAction,casterHero,targetHero);
        }

       /// <summary>
       /// After confirming target is alive, check if caster is still alive
       /// </summary>
       /// <param name="basicAction"></param>
       /// <param name="casterHero"></param>
       /// <param name="targetHero"></param>
        public override void TargetMainAnimation(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //call the hero alive status of the original caster hero (the attacker, or healer)
            targetHero.HeroLogic.HeroLifeStatus.CasterMainAnimation(basicAction,casterHero,targetHero);
        }
        
        /// <summary>
        /// After confirming caster is alive, execute main animation action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterMainAnimation(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //calls the action if the caster is still alive 
            //TODO - Does this have to be an IEnumerator? Nothing wrong with IEnumerator so far
            logicTree.AddCurrent(basicAction.MainAnimation(casterHero,targetHero));
        }
        
        /// <summary>
        /// Add a living hero to a heroes list.  Example use: basic actions
        /// </summary>
        /// <param name="heroes"></param>
        /// <param name="hero"></param>
        public override void AddToHeroList(List<IHero> heroes, IHero hero)
        {
           heroes.Add(hero);
        }

    
        
        


    }
}
