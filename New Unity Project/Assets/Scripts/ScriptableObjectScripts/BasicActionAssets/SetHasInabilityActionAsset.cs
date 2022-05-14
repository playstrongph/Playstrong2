using System.Collections;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "SetHasInabilityAction", menuName = "Assets/BasicActions/S/SetHasInabilityAction")]
    public class SetHasInabilityActionAsset : BasicActionAsset
    {

        [SerializeField] private int inabilityFactor = 100;
        
        
        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var inabilityResistance = targetHero.HeroLogic.ResistanceAttributes.InabilityResistance;
            
            //if there are no inability immunities
            if (inabilityResistance <= 0)
            {
                //Increase inability factor, for multiple inabilities
                targetHero.HeroLogic.InabilityFactor += inabilityFactor;
                targetHero.HeroLogic.SetHeroInabilityStatus.HasInability();
            }
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            targetHero.HeroLogic.InabilityFactor -= inabilityFactor;
            
            //Only remove inability if there are no overlapping inabilities - e.g. stun, sleep, unique effects, etc.
            if(targetHero.HeroLogic.InabilityFactor <=0)
                targetHero.HeroLogic.SetHeroInabilityStatus.NoInability();

            logicTree.EndSequence();
            yield return null;
        }
        
        

    }
}
