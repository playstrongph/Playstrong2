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

        private bool _enablePreview = false;
        private void Awake()
        {
            _targetCollider = GetComponent<ITargetCollider>();
        }

        private IEnumerator ShowHeroPreview()
        {
            yield return new WaitForSeconds(displayDelay);
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            if(_enablePreview)
                _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = true;
        }
        
        private void HideHeroPreview()
        {
            _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
            _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = false;
        }

        private void OnMouseDown()
        {
            _enablePreview = true;
            StartCoroutine(ShowHeroPreview());
        }

        private void OnMouseUp()
        {
            _enablePreview = false;
            HideHeroPreview();
        }

        private void OnMouseExit()
        {
            _enablePreview = false;
            HideHeroPreview();
        }
        
        
    }
}
