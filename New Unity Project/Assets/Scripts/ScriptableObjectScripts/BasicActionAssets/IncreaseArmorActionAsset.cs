﻿using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.CalculatedValuesAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using TMPro;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "IncreaseArmorAction", menuName = "Assets/BasicActions/I/IncreaseArmorAction")]
    public class IncreaseArmorActionAsset : BasicActionAsset
    {   
        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [SerializeField] private int flatValue = 0;
        
        /// <summary>
        /// Increase value by a percentage attack amount
        /// </summary>
        [SerializeField] private int percentBaseHealthValue = 0;
        
        /// <summary>
        /// Calculated value
        /// </summary>
        [SerializeField] private ScriptableObject calculatedValueAsset;
        private ICalculatedValueAsset CalculatedValueAsset
        {
            get => calculatedValueAsset as ICalculatedValueAsset;
            set => calculatedValueAsset = value as ScriptableObject;
        }
        
        
        /// <summary>
        /// 1 for increase, -1 for decrease.  Default is 1 or increase
        /// </summary>
        [Header("CHANGE VALUE MULTIPLIER")] [SerializeField]
        private int changeMultiplier = 1;

        /// <summary>
        /// change in attribute value - used by execute and undo execute action
        /// </summary>
        private int changeValue = 0;

        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }


        /// <summary>
        /// Increase attack logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var baseValue = targetHero.HeroLogic.HeroAttributes.BaseHealth;

            var calculatedValue = 0;

            if (CalculatedValueAsset != null)
            {
                calculatedValue = (int)CalculatedValueAsset.CalculatedValue;
            }

            //Compute change in attack value
            changeValue = Mathf.RoundToInt(baseValue * percentBaseHealthValue / 100f) + flatValue +calculatedValue;
            
            //Multiply with factor
            changeValue *= changeMultiplier;

            var newValue = targetHero.HeroLogic.HeroAttributes.Armor + changeValue;
            
            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetArmor.StartAction(newValue);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            //var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            //Use the change value set in execute action earlier
            var newValue = targetHero.HeroLogic.HeroAttributes.Armor - changeValue;
            
            //Set the new attack value in hero attributes
            targetHero.HeroLogic.SetArmor.StartAction(newValue);

            logicTree.EndSequence();
            yield return null;
        }

    }
}