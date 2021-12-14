using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Displays skill preview after a delay
    /// </summary>
    public class DisplaySkillPreview : MonoBehaviour, IDisplaySkillPreview
    {
        private ISkillTargetCollider _skillTargetCollider;
        
        /// <summary>
        /// Amount of delay before Hero Preview is shown
        /// </summary>
        [SerializeField] private float displayDelay = 0.5f;

        private bool _enablePreview = false;
        private void Awake()
        {
            _skillTargetCollider = GetComponent<ISkillTargetCollider>();
        }
        
        /// <summary>
        /// Coroutine used to introduce a delay before showing the hero preview
        /// </summary>
        /// <returns></returns>
        private IEnumerator ShowPreview()
        {
            yield return new WaitForSeconds(displayDelay);
            if (_enablePreview)
            {
                _skillTargetCollider.Skill.SkillPreview.PreviewCanvas.enabled = true;
                _skillTargetCollider.Skill.SkillPreview.ThisGameObject.SetActive(true);    
            }
        }
        
        private void HidePreview()
        {
            _skillTargetCollider.Skill.SkillPreview.PreviewCanvas.enabled = false;
            _skillTargetCollider.Skill.SkillPreview.ThisGameObject.SetActive(false);
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
}
