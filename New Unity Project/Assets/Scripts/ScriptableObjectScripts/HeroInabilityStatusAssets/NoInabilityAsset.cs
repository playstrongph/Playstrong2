using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
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
        /// <returns></returns>
        public override IEnumerator TurnControllerAction(ITurnController turnController)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;
            
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
            Debug.Log("No Inability: " +basicAction.ToString());
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(basicAction.ExecuteAction(casterHero,targetHero));  
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
    }
}
