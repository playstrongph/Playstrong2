using ScriptableObjectScripts.StatusEffectCastingStatusAssets;

namespace Logic
{
    public interface IUpdateStatusEffectCastingStatus
    {
        /// <summary>
        /// When the target hero and caster hero of the status effect is the same this turn
        /// Example circumstances - Buff all allies (the caster hero is also a target). 
        /// </summary>
        IStatusEffectCastingStatusAsset FreshCastAsset { get; }

        IStatusEffectCastingStatusAsset OldCastAsset { get; }
    }
}