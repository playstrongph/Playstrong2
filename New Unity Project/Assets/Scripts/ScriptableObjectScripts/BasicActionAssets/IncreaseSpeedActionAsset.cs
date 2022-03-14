using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseSpeedAction", menuName = "Assets/BasicActions/I/IncreaseSpeedAction")]
    public class IncreaseSpeedActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Increase value by a percentage speed amount
        /// </summary>
        [SerializeField] private int percentValue = 0;
        
        //TODO: CalculatedValue
        
        /// <summary>
        /// change in attribute value - used by execute and undo execute action
        /// </summary>
        private int _changeValue = 0;
        
        /// <summary>
        /// Increase speed logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var baseValue = targetHero.HeroLogic.HeroAttributes.BaseSpeed;
            
            //Compute change in attack value
            _changeValue = Mathf.RoundToInt(baseValue * percentValue / 100f) + flatValue;

            var newValue = targetHero.HeroLogic.HeroAttributes.Speed + _changeValue;
            
            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetSpeed.StartAction(newValue);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            var newValue = targetHero.HeroLogic.HeroAttributes.Speed - _changeValue;
            
            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetSpeed.StartAction(newValue);

            logicTree.EndSequence();
            yield return null;
        }
        
     
        
        
    }
}
