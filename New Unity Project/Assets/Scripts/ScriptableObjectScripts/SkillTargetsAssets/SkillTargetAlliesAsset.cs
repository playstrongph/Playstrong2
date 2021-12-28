using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetAllies", menuName = "Assets/SkillTargets/SkillTargetAllies")]
    public class SkillTargetAlliesAsset : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            return new List<IHero>(hero.Player.AliveHeroes.Heroes);
        }
        
        /// <summary>
        /// Displays the ally glow - yellow
        /// </summary>
        /// <param name="hero"></param>
        public override void ShowHeroGlow(IHero hero)
        {
            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.EnableAllyLightAndGlow();
            
        }
        
        /// <summary>
        /// Hides the ally glow - yellow
        /// </summary>
        /// <param name="hero"></param>
        public override void HideHeroGlow(IHero hero)
        {
            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.DisableAllyLightAndGlow();
        }
        
        
    }
}
