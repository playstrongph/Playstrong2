using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicConditionAssets
{
    [CreateAssetMenu(fileName = "HasNoSpecificStatusEffectCondition", menuName = "Assets/BasicConditions/H/HasNoSpecificStatusEffectCondition")]
    public class HasNoSpecificStatusEffectConditionAsset : BasicConditionAsset
    {
        [Header("Does Not Have This Specific Status Effect")]
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
            
            //Check if status effect is present
            foreach (var statusEffect in statusEffects)
            {
                if (statusEffect.StatusEffectName == StatusEffectAsset.StatusEffectName)
                    value = 1;
            }
            
            
            
            //Returns 0 if status effect is present and 1 if not present
            value = value == 1 ? 0 : 1;
            
            Debug.Log("Has No Specific Status Effect. Value: " +value);

            return value;
        }
    }
}
