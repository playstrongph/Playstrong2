using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    [CreateAssetMenu(fileName = "NoInability", menuName = "Assets/HeroInabilityStatus/NoInability")]
    public class NoInabilityAsset : HeroInabilityStatusAsset
    {
        /// <summary>
        /// Hero proceeds to start the turn
        /// </summary>
        /// <param name="turnController"></param>
        /// <param name="currentActiveHero"></param>
        /// <returns></returns>
        public override IEnumerator TurnControllerAction(ITurnController turnController,IHero currentActiveHero)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;

            Debug.Log("No Inability, Inability factor: " +currentActiveHero.HeroLogic.InabilityFactor 
                                                         +" Hero Inability Status: " +currentActiveHero.HeroLogic.HeroInabilityStatus);
            
            turnController.BeforeHeroStartTurn.HeroStartTurn();
            
            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Executes basic action if caster has no inability
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void ExecuteBasicAction(IBasicActionAsset basicAction, IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(basicAction.ExecuteAction(casterHero,targetHero));  
        }
        
        
        //TODO: StandardActionStartAction
        public override void ExecuteStandardAction(IStandardActionAsset standardAction, IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(standardAction.ExecuteStartAction(casterHero,targetHero));
            
        }


        /// <summary>
        ///  Calls pre basic action events if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CallPreBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(basicAction.CallPreBasicActionEvents(casterHero,targetHero));
        }
        
        /// <summary>
        /// // Calls post basic action events if caster has no Inabilities
        /// </summary>
        /// <param name="basicAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void CallPostBasicActionEvents(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            logicTree.AddCurrent(basicAction.CallPostBasicActionEvents(casterHero,targetHero));
        }
        
        /// <summary>
        /// If there are no inabilities, proceed with the skill action
        /// </summary>
        /// <param name="skillAction"></param>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public override void SkillStartAction(ISkillActionAsset skillAction, IHero casterHero, IHero targetHero)
        {
            skillAction.SkillStartAction(casterHero,targetHero);
        }
    }
}
