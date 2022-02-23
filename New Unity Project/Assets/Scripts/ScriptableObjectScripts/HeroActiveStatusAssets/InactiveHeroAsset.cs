using System.Collections;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroActiveStatusAssets
{
    /// <summary>
    /// Hero Inactive Status
    /// </summary>
    [CreateAssetMenu(fileName = "InactiveHero", menuName = "Assets/HeroActiveStatus/InactiveHero")]
    public class InactiveHeroAsset : HeroActiveStatusAsset
    {
        public override void StatusAction(IHero hero)
        {
            Debug.Log("Inactive Hero Status Action: " +hero.HeroName);
            
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(DisableActiveHeroVisuals(hero));
        }
        
        private IEnumerator DisableActiveHeroVisuals(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            //Hides green action border
            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.DisableActionLightAndGlow();
            
            //Hides hero portrait
            hero.HeroPortrait.TogglePortraitDisplay.HidePortrait();
            
            //Hides Hero Skills
            hero.HeroSkills.HideHeroSkills();

            visualTree.EndSequence();
            yield return null;
        }
    }
}
