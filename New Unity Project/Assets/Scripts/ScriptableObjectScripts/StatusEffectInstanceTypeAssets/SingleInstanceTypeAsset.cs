using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    /// <summary>
    /// Status effects that can only have 1 instance per hero at a time during combat
    /// </summary>
    [CreateAssetMenu(fileName = "SingleInstanceType", menuName = "Assets/StatusEffectsInstanceTypeAsset/SingleInstanceType")]
    public class SingleInstanceTypeAsset : StatusEffectInstanceTypeAsset
    {
        public override void AddStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            var existingStatusEffect = CheckForExistingStatusEffect(targetHero, statusEffectAsset);
            
            if(existingStatusEffect != null)
                UpdateStatusEffect(targetHero,casterHero,existingStatusEffect,statusEffectAsset,counters);
            else
            {
                logicTree.AddCurrent(CreateStatusEffect(targetHero,casterHero,statusEffectAsset,counters));
            }
            
            if(NewStatusEffect.CountersValue <=0)
                NewStatusEffect.RemoveStatusEffect.StartAction(targetHero);

        }
    }
}
