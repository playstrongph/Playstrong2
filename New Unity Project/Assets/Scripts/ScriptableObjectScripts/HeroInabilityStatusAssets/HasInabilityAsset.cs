using System.Collections;
using Logic;
using ScriptableObjectScripts.BasicActionAssets;
using UnityEngine;

namespace ScriptableObjectScripts.HeroInabilityStatusAssets
{
    
    [CreateAssetMenu(fileName = "HasInability", menuName = "Assets/HeroInabilityStatus/HasInability")]
    public class HasInabilityAsset : HeroInabilityStatusAsset
    {
        /// <summary>
        /// Hero misses his turn and proceed to after hero end turn
        /// </summary>
        /// <param name="turnController"></param>
        /// <param name="currentActiveHero"></param>
        /// <returns></returns>
        public override IEnumerator TurnControllerAction(ITurnController turnController,IHero currentActiveHero)
        {
            var logicTree = turnController.CoroutineTrees.MainLogicTree;
            
            Debug.Log("Has Inability, Inability factor: " +currentActiveHero.HeroLogic.InabilityFactor);

            //Delay allows to cleanup the Heroes Turn Queue for dead heroes
            logicTree.AddSibling(turnController.AfterHeroEndTurn.StartAction());

            logicTree.EndSequence();
            yield return null;
        }

        public override void ExecuteBasicAction(IBasicActionAsset basicAction, IHero casterHero, IHero targetHero)
        {
            Debug.Log("CasterHero: " +casterHero.HeroName);
            Debug.Log("TargetHero: " +targetHero.HeroName);
            
            Debug.Log("Caster Inability Status: " +casterHero.HeroLogic.HeroInabilityStatus);
            Debug.Log("Target Inability Status: " +targetHero.HeroLogic.HeroInabilityStatus);
        }

        
        
        
        
    }
}
