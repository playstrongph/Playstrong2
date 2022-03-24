using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.SkillTargetsAssets
{
    [CreateAssetMenu(fileName = "SkillTargetEnemies", menuName = "Assets/SkillTargets/SkillTargetEnemies")]
    public class SkillTargetEnemiesAsset : SkillTargetsAsset
    {
        public override List<IHero> HeroTargets(IHero hero)
        {
            var allEnemies = new List<IHero>(hero.Player.OtherPlayer.AliveHeroes.Heroes);
            var validTargets = new List<IHero>();

            /*foreach (var enemyHero in allEnemies)
            {
                var attackTargetResistance = enemyHero.HeroLogic.ResistanceAttributes.TargetAttackResistance;
                if (attackTargetResistance <= 0 )
                    validTargets.Add(enemyHero);
            }*/

            validTargets = GetTargets(hero);
            
            return validTargets;
        }
        
        /// <summary>
        /// Sorts out stealth and taunt heroes
        /// </summary>
        /// <returns></returns>
        private List<IHero> GetTargets(IHero hero)
        {
            var allEnemies = new List<IHero>(hero.Player.OtherPlayer.AliveHeroes.Heroes);
            var finalTargets = new List<IHero>(hero.Player.OtherPlayer.AliveHeroes.Heroes);
            var tauntEnemies = new List<IHero>();
            var stealthEnemies = new List<IHero>();

            //Remove stealth targets from the final targets
            foreach (var enemy in allEnemies)
            {
                if (enemy.HeroLogic.ResistanceAttributes.TargetAttackResistance > 0)
                {
                    stealthEnemies.Add(enemy);
                    finalTargets.Remove(enemy);
                }
            }
            
            //If there are no targets left, assign stealth enemies as final targets
            if (finalTargets.Count <= 0)
                finalTargets = stealthEnemies;
            
            //Get all taunt targets
            foreach (var enemy in allEnemies)
            {
                if(enemy.HeroLogic.ResistanceAttributes.TargetAttackResistance < 0)
                    tauntEnemies.Add(enemy);
            }
            
            //Assign only taunt enemies as the final targets 
            if (tauntEnemies.Count > 0)
            {
                finalTargets.Clear();
                finalTargets = tauntEnemies;
            }

            return finalTargets;
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
