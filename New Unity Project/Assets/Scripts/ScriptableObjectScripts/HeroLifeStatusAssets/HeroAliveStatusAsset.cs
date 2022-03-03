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
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void TargetMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //Check if the caster is still alive
            targetHero.HeroLogic.HeroLifeStatus.CasterMainExecutionAction(basicAction,casterHero,targetHero);
        }

        /// <summary>
        /// HeroAlive - basic action Execute action 
        /// After confirming, caster is alive, execute action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterMainExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            //Original
            //logicTree.AddCurrent(basicAction.ExecuteAction(casterHero,targetHero));
            
            //Calls basic action when caster has no inabilities
            casterHero.HeroLogic.HeroInabilityStatus.ExecuteBasicAction(basicAction,casterHero,targetHero);
        }
        
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
        /// After confirming the caster is alive, implement the basic action's
        /// pre execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterPreExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
        
            //calls the action if the caster is still alive 
            //TODO - Does this have to be an IEnumerator? Nothing wrong with IEnumerator so far
            logicTree.AddCurrent(basicAction.CallPreBasicActionEvents(casterHero,targetHero));
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
        /// After confirming the caster is alive, implement the basic action's
        /// post execution action
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CasterPostExecutionAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //calls the action if the caster is still alive 
            //TODO - Does this have to be an IEnumerator? Nothing wrong with IEnumerator so far
            logicTree.AddCurrent(basicAction.CallPostBasicActionEvents(casterHero,targetHero));
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

      
    }
}
