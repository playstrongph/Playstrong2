using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class DisplayHeroPreview : MonoBehaviour
    {
        private ITargetCollider _targetCollider;
        
        /// <summary>
        /// Amount of delay before Hero Preview is shown
        /// </summary>
        [SerializeField] private float displayDelay = 0.5f;

        private void Awake()
        {
            _targetCollider = GetComponent<ITargetCollider>();
        }

        public IEnumerator ShowHeroPreview()
        {
            yield return new WaitForSeconds(displayDelay);
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = true;
            yield return null;
        }
        
        public void HideHeroPreview()
        {
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            
            _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = true;
        }
    }
}
