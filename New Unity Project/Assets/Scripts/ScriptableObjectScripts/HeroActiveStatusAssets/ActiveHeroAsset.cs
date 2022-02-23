using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroActiveStatusAssets
{
    /// <summary>
    /// Hero Active Status
    /// </summary>
    [CreateAssetMenu(fileName = "ActiveHero", menuName = "Assets/HeroActiveStatus/ActiveHero")]
    public class ActiveHeroAsset : HeroActiveStatusAsset
    {   
        /// <summary>
        /// Displays green action border, hero portrait, and hero skills
        /// </summary>
        /// <param name="hero"></param>
        public override void StatusAction(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            visualTree.AddCurrent(EnableActiveHeroVisuals(hero));
            
            //Note: Current usages are logic trees, so we can go direct to visual tree here
        }


        /// <summary>
        /// Displays green action border, hero portrait, and hero skills
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private IEnumerator EnableActiveHeroVisuals(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            //Displays green action border
            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.EnableActionLightAndGlow();
            
            //Displays hero portrait
            hero.HeroPortrait.TogglePortraitDisplay.ShowPortrait();
            
            //Displays Hero Skills
            hero.HeroSkills.ShowHeroSkills();

            visualTree.EndSequence();
            yield return null;
        }
    }
}
