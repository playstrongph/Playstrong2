using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetOtherAllies", menuName = "Assets/SkillTargets/SkillTargetOtherAllies")]
    public class SkillTargetOtherAlliesAsset : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            var otherAllies = new List<IHero>(hero.Player.AliveHeroes.Heroes);
            
            //remove the skill caster's hero from the allies list
            otherAllies.Remove(hero);
            
            return otherAllies;
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
