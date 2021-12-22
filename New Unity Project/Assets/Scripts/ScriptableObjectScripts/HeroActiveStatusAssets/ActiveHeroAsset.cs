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
        public override void StatusAction(IHero hero)
        {
            Debug.Log("Active Hero");

            var visualTree = hero.CoroutineTrees.MainVisualTree;
            visualTree.AddCurrent(VisualEnableActionHeroGlow(hero));
        }
        
        private IEnumerator VisualEnableActionHeroGlow(IHero hero)
        {
            var visualTree = hero.CoroutineTrees.MainVisualTree;

            hero.HeroVisual.SetHeroFrameAndGlow.CurrentHeroFrame.EnableActionLightAndGlow();

            visualTree.EndSequence();
            yield return null;
        }
    }
}
