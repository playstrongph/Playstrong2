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

        private bool enablePreview = false;
        private void Awake()
        {
            _targetCollider = GetComponent<ITargetCollider>();
        }

        private IEnumerator ShowHeroPreview()
        {
            yield return new WaitForSeconds(displayDelay);
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            if(enablePreview)
                _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = true;
            yield return null;
        }
        
        private IEnumerator HideHeroPreview()
        {
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = false;
            
            yield return new WaitForSeconds(displayDelay);
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = false;
            yield return null;
        }

        private void OnMouseDown()
        {
            enablePreview = true;
            StartCoroutine(ShowHeroPreview());
        }

        private void OnMouseUp()
        {
            enablePreview = false;
            StopCoroutine(ShowHeroPreview());
            StartCoroutine(HideHeroPreview());

        }
    }
}
