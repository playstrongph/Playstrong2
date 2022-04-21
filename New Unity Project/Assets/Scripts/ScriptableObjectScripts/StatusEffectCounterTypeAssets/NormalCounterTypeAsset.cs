using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectCounterTypeAssets
{
    [CreateAssetMenu(fileName = "NormalCounterType", menuName = "Assets/StatusEffectCounterType/NormalCounterType")]
    public class NormalCounterTypeAsset : StatusEffectCounterTypeAsset
    {
        /// <summary>
        /// Fixed normal turn counter reduction, 1 by default
        /// </summary>
        [SerializeField] private int fixedReduction = 1;
        
        /// <summary>
        /// Increase the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public override void IncreaseCounters(IStatusEffect statusEffect, int counters)
        {
            var logicTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            
            statusEffect.CountersValue += counters;
            
            statusEffect.CountersValue = Mathf.Max(0, statusEffect.CountersValue);
            
            logicTree.AddCurrent(UpdateCountersVisual(statusEffect));
            
            logicTree.AddCurrent(CheckRemoveStatusEffect(statusEffect));
        }
        
        /// <summary>
        ///  Decrease the status effect counters by the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public override void DecreaseCounters(IStatusEffect statusEffect, int counters)
        {
            var logicTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            
            statusEffect.CountersValue -= counters;

            statusEffect.CountersValue = Mathf.Max(0, statusEffect.CountersValue);

            logicTree.AddCurrent(UpdateCountersVisual(statusEffect));
            
            logicTree.AddCurrent(CheckRemoveStatusEffect(statusEffect));
            
            
        }
        
        /// <summary>
        ///  Set the status effect counters to the specified amount
        /// </summary>
        /// <param name="statusEffect"></param>
        /// <param name="counters"></param>
        public override void SetCountersToValue(IStatusEffect statusEffect, int counters)
        {
            var logicTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            
            statusEffect.CountersValue = counters;

            statusEffect.CountersValue = Mathf.Max(0, statusEffect.CountersValue);

            logicTree.AddCurrent(UpdateCountersVisual(statusEffect));

            logicTree.AddCurrent(CheckRemoveStatusEffect(statusEffect));
        }
        
        /// <summary>
        /// Reduce the status effect counters by a fixed amount (1)
        /// </summary>
        /// <param name="statusEffect"></param>
        public override void TurnReduceCounters(IStatusEffect statusEffect)
        {
            var logicTree = statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;

            statusEffect.CountersValue -= fixedReduction;
            statusEffect.CountersValue = Mathf.Max(0, statusEffect.CountersValue);
            
            logicTree.AddCurrent(UpdateCountersVisual(statusEffect));
            
            logicTree.AddCurrent(CheckRemoveStatusEffect(statusEffect));
        }

        
    }
}
