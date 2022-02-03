using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.StatusEffectInstanceTypeAssets
{
    /// <summary>
    /// Status effects that can have more than 1 instance per hero at a time during combat
    /// </summary>
    [CreateAssetMenu(fileName = "MultipleInstanceType", menuName = "Assets/StatusEffectsInstanceTypeAsset/MultipleInstanceType")]
    public class MultipleInstanceTypeAsset : StatusEffectInstanceTypeAsset
    {
       
        public override void AddStatusEffect(IHero targetHero, IHero casterHero, IStatusEffectAsset statusEffectAsset, int counters)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(CreateStatusEffect(targetHero,casterHero,statusEffectAsset,counters));
        }
        
    }
}
