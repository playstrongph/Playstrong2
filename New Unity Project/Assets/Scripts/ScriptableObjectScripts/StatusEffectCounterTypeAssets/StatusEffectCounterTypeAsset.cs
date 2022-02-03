using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCounterTypeAssets
{
    /// <summary>
    /// Base class for normal and immutable status effect counter types
    /// </summary>
    public abstract class StatusEffectCounterTypeAsset : ScriptableObject, IStatusEffectCounterTypeAsset
    {
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public virtual void IncreaseCounters(IStatusEffect statusEffect, int counters)
        { }
        
        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public virtual void DecreaseCounters(IStatusEffect statusEffect, int counters)
        { }
        
        /// <summary>
        ///  Set the status effect counters to the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public virtual void SetCountersToValue(IStatusEffect statusEffect, int counters)
        { }
        
        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// </summary>
        /// <param name="statusEffect"></param>
        public virtual void TurnReduceCounters(IStatusEffect statusEffect)
        { }
        
        
        /// <summary>
        /// Logic tree wrapper for visual counters update
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <returns></returns>
        protected IEnumerator UpdateCountersVisual(IStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            var visualTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(VisualUpdate(statusEffect));
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Visual tree counters update
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <returns></returns>
        private IEnumerator VisualUpdate(IStatusEffect statusEffect)
        {
            var visualTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainVisualTree;

            statusEffect.CountersText.text = statusEffect.CountersValue.ToString();

            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Logic wrapper for visual effect
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <returns></returns>
        protected IEnumerator CheckRemoveStatusEffect(IStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            var visualTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(CheckRemoveStatusEffectVisual(statusEffect));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Removes the status effect when the counters is less or equal to zero.
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <returns></returns>
        private IEnumerator CheckRemoveStatusEffectVisual(IStatusEffect statusEffect)
        {
            var visualTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainVisualTree;
            
            if(statusEffect.CountersValue <=0)
                statusEffect.RemoveStatusEffect.StartAction(statusEffect.StatusEffectTargetHero);
            
            visualTree.EndSequence();
            yield return null;
        }


    }
}
