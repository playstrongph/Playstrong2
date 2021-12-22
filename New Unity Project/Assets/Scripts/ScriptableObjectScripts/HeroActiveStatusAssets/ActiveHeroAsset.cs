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
            
        }
        
        private IEnumerator VisualEnableActionHeroGlow(IHero hero)
        {
            var heroLogic = hero.HeroLogic;
            var visualTree = hero.CoroutineTrees.MainVisualTree;
            
            //var actionGlowFrame = heroLogic.Hero.HeroVisual.SetHeroFrameAndGlow.HeroFrameAndGlow.ActionGlowFrame;
            //actionGlowFrame.SetActive(true);
            
            visualTree.EndSequence();
            yield return null;
        }
    }
}
