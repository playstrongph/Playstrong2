﻿using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    
    
    /// <summary>
    /// Increases the damage reduction factor for all types of take damage
    /// Example - Invincibility
    /// </summary>
    [CreateAssetMenu(fileName = "IncreaseTakeAllDamageReduction", menuName = "Assets/BasicActions/I/IncreaseTakeAllDamageReduction")]
    public class IncreaseTakeAllDamageReductionAsset : BasicActionAsset
    {
        /// <summary>
        /// Value of damage reduction
        /// </summary>
        [SerializeField] private int value = 0;
        
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var damageAttributes = targetHero.HeroLogic.DamageAttributes;

            damageAttributes.AllTakeDamageReduction += value;
            
            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator UndoExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var damageAttributes = targetHero.HeroLogic.DamageAttributes;

            damageAttributes.AllTakeDamageReduction -= value;
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
