using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.CalculatedValuesAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseFightingSpiritAction", menuName = "Assets/BasicActions/I/IncreaseFightingSpiritAction")]
    public class IncreaseFightingSpiritActionAsset : BasicActionAsset
    {   
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Set multiplier to 1 to enable, 0 is disabled
        /// </summary>
        [Header("Multipliers")]
        [SerializeField] private int flatMultiplier = 1; //Default value is 1 (increase by flat value amount);

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICalculatedValueAsset))]private List<ScriptableObject> calculatedValueAssets;
        private List<ICalculatedValueAsset> CalculatedValueAssets
        {
            
            get
            {
                var newCalculatedValueAssets = new List<ICalculatedValueAsset>();
                foreach (var calculatedValueAssetObject in calculatedValueAssets)
                {
                    var newCalculatedValueAsset = calculatedValueAssetObject as ICalculatedValueAsset;
                    newCalculatedValueAssets.Add(newCalculatedValueAsset);
                }
                return newCalculatedValueAssets;
            }

            set => calculatedValueAssets = new List<ScriptableObject>();
        }

        
       

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
            logicTree.AddCurrent(MainAction(targetHero));

            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Increase target hero attribute
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            //This is the final multiplier to the fighting spirit flat value
            var totalMultiplier = 0f;
            
            //Increase total multiplier by calculated value assets
            foreach (var calculatedValue in CalculatedValueAssets)
            {
                totalMultiplier += calculatedValue.CalculatedValue;
            }
            
            //Increase total multiplier by a flat multiplier factor
            totalMultiplier += flatMultiplier;
            
            //TODO: Insert other multipliers here in the future
            
            //This is the final change in fighting spirit value  
            var finalFightingSpiritDeltaValue = flatValue * Mathf.RoundToInt(totalMultiplier);
            
            
            //If there will be a chance in the fighting spirit amount, whether negative or positive
            if (finalFightingSpiritDeltaValue != 0)
            {
                //Total fighting spirit increase is totalMultiplier * fighting spirit flat value
                var fightingSpirit = targetHero.HeroLogic.HeroAttributes.FightingSpirit + finalFightingSpiritDeltaValue;

                targetHero.HeroLogic.SetFightingSpirit.StartAction(fightingSpirit);    
            }

            logicTree.EndSequence();
            yield return null;
        }
        
      



    }
}
