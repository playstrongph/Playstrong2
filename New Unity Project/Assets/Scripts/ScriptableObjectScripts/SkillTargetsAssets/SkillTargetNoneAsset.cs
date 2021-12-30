using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{   
    /// <summary>
    /// Used by passive skills, returns an empty heroes list
    /// </summary>
    [CreateAssetMenu(fileName = "SkillTargetNone", menuName = "Assets/SkillTargets/SkillTargetNone")]
    public class SkillTargetNoneAsset : SkillTargetsAsset
    {
        /// <summary>
        /// Return an empty list
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        public override List<IHero> HeroTargets(IHero hero)
        {
            return new List<IHero>();
        }
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="hero"></param>
        public override void ShowHeroGlow(IHero hero)
        {
        }
        
        
        /// <summary>
        /// No Action
        /// </summary>
        /// <param name="hero"></param>
        public override void HideHeroGlow(IHero hero)
        {
        
        }
    }
}
