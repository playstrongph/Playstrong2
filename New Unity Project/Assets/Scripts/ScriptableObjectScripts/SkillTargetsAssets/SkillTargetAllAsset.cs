using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetAll", menuName = "Assets/SkillTargets/SkillTargetAll")]
    public class SkillTargetAllAsset : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            var allHeroes = new List<IHero>(hero.Player.AliveHeroes.Heroes);
            
            allHeroes.AddRange(hero.Player.OtherPlayer.AliveHeroes.Heroes);
            
            return allHeroes;
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
