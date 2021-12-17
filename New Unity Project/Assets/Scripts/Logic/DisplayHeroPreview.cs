using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Displays hero preview after a delay
/// </summary>
public class DisplayHeroPreview : MonoBehaviour, IDisplayHeroPreview
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
        
    /// <summary>
    /// Coroutine used to introduce a delay before showing the hero preview
    /// </summary>
    /// <returns></returns>
    private IEnumerator ShowPreview()
    {
        yield return new WaitForSeconds(displayDelay);
        _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
        if (_enablePreview)
        {
            _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = true;
            _targetCollider.Hero.HeroPreview.ThisGameObject.SetActive(true);    
        }

            
    }
        
    private void HidePreview()
    {
        _targetCollider.Hero.HeroPreview.UpdateHeroPreview.StartAction();
        _targetCollider.Hero.HeroPreview.PreviewCanvas.enabled = false;
        _targetCollider.Hero.HeroPreview.ThisGameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        _enablePreview = true;
        StartCoroutine(ShowPreview());
    }

    private void OnMouseUp()
    {
        _enablePreview = false;
        HidePreview();
    }

    private void OnMouseExit()
    {
        _enablePreview = false;
        HidePreview();
    }
        
        
}