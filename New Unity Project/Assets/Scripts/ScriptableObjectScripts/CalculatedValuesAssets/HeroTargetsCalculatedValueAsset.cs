using System.Collections.Generic;
using Logic;
using ScriptableObjectScripts.ActionTargetAssets;
using UnityEngine;

namespace ScriptableObjectScripts.CalculatedValuesAssets
{
    [CreateAssetMenu(fileName = "HeroTargetsCalculatedValue", menuName = "Assets/CalculatedValues/HeroTargetsCalculatedValue")]
    public class HeroTargetsCalculatedValueAsset : CalculatedValueAsset
    {
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IActionHeroesAsset))]private ScriptableObject actionHeroesAsset;
        private IActionHeroesAsset ActionHeroesAsset
        {
            get => actionHeroesAsset as IActionHeroesAsset;
            set => actionHeroesAsset = value as ScriptableObject;
        }

        public override List<IHero> GetCalculatedHeroList(IHero heroBasis)
        {
            CalculatedHeroes = ActionHeroesAsset.SetActionHeroes(heroBasis, heroBasis);
            
            return CalculatedHeroes;
        }
    }
}
