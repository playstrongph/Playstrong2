using System;
using System.Collections;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace Logic
{
    public class StatusEffectSymbol : MonoBehaviour, IStatusEffectSymbol
    {
        private IStatusEffect _statusEffect;
        
        //TEST
        [Header("ANIMATIONS")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject addStatusEffectAnimationAsset;
        /// <summary>
        /// Floating Text animation asset
        /// </summary>
        private IGameAnimationsAsset AddStatusEffectAnimationAsset
        {
            get => addStatusEffectAnimationAsset as IGameAnimationsAsset;
            set => addStatusEffectAnimationAsset = value as ScriptableObject;
        }

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
            
            //TEST
            //visualTree.AddCurrent(AddStatusEffectVisual(_statusEffect.StatusEffectTargetHero));
            
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
        
        /// <summary>
        /// Add status effect animation
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator AddStatusEffectVisual(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            //set status effect text name
            var statusEffectText = _statusEffect.StatusEffectName;

            AddStatusEffectAnimationAsset.PlayAnimation(statusEffectText,targetHero);
            
            visualTree.EndSequence();
            yield return null;
        }
        
        
        
        

       
    }
}
