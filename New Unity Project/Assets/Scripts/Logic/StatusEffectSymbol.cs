using System;
using System.Collections;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace Logic
{
    public class StatusEffectSymbol : MonoBehaviour, IStatusEffectSymbol
    {
        private IStatusEffect _statusEffect;

        private void Awake()
        {
            _statusEffect = GetComponent<IStatusEffect>();
        }
        
        
        /// <summary>
        /// Hides the status effect symbol
        /// </summary>
        public void HideSymbol()
        {
            var icon = _statusEffect.Icon;
            var frame = _statusEffect.Frame;
            var countersText = _statusEffect.CountersText;

            icon.enabled = false;
            frame.enabled = false;
            countersText.enabled = false;

        }
        
        /// <summary>
        /// Displays the status effect symbol
        /// </summary>
        public void ShowSymbol()
        {
            var logicTree = _statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            
            logicTree.AddCurrent(ShowSymbolVisual());

        }

        private IEnumerator ShowSymbolVisual()
        {
            var logicTree = _statusEffect.StatusEffectTargetHero.CoroutineTrees.MainLogicTree;
            var visualTree = _statusEffect.StatusEffectTargetHero.CoroutineTrees.MainVisualTree;

            visualTree.AddCurrent(DisplayStatusEffectIcon());

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator DisplayStatusEffectIcon()
        {
           
            var visualTree = _statusEffect.StatusEffectTargetHero.CoroutineTrees.MainVisualTree;
            
            var icon = _statusEffect.Icon;
            var frame = _statusEffect.Frame;
            var countersText = _statusEffect.CountersText;

            icon.enabled = true;
            frame.enabled = true;
            countersText.enabled = true;
            
            visualTree.EndSequence();
            yield return null;
        }
        
       
        
        
        
        

       
    }
}
