using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "HasSpecificStatusEffectCondition", menuName = "Assets/BasicConditions/H/HasSpecificStatusEffectCondition")]
    public class HasSpecificStatusEffectConditionAsset : BasicConditionAsset
    {
        [Header("Has This Specific Status Effect")]
        [SerializeField] private ScriptableObject statusEffectAsset;
        
        private IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }

        protected override int CheckConditionValue(IHero hero)
        {
            //Default is False
            var value = 0;
            
            var statusEffects = hero.HeroStatusEffects.GetAllStatusEffects(hero);
            
            //If status effect is present
            foreach (var statusEffect in statusEffects)
            {
                if (statusEffect.StatusEffectName == StatusEffectAsset.StatusEffectName)
                    value = 1;
            }
            
            Debug.Log("Has Specific Status Effect. Value: " +value);
            
            return value;
        }
    }
}
