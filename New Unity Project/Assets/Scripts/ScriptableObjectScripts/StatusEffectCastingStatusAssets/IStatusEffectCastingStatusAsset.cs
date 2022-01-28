using Logic;

namespace ScriptableObjectScripts.StatusEffectCastingStatusAssets
{
    public interface IStatusEffectCastingStatusAsset
    {
        void StartAction(IStatusEffect statusEffect);
    }
}