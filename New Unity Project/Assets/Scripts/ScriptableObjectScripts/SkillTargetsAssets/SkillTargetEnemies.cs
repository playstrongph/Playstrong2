using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetEnemies", menuName = "Assets/SkillTargets/SkillTargetEnemies")]
    public class SkillTargetEnemies : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            var allEnemies = new List<IHero>(hero.Player.OtherPlayer.AliveHeroes.Heroes);
            var validTargets = new List<IHero>();

            foreach (var enemyHero in allEnemies)
            {
                var attackTargetResistance = enemyHero.HeroLogic.OtherHeroAttributes.AttackTargetAssistance;
                if (attackTargetResistance <= 0 )
                    validTargets.Add(enemyHero);
            }
            
            return validTargets;
        }
        /// <summary>
        /// Displays the enemy glow - red
        /// </summary>
        /// <param name="hero"></param>
        public override void ShowHeroGlow(IHero hero)
        {
            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.EnableEnemyLightAndGlow();
        }
        
        /// <summary>
        /// Hides the enemy glow - red
        /// </summary>
        /// <param name="hero"></param>
        public override void HideHeroGlow(IHero hero)
        {
            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.DisableEnemyLightAndGlow();
        }

    }
}
