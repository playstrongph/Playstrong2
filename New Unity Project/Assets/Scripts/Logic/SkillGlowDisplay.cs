using System;
using UnityEngine;

namespace Logic
{
    public class SkillGlowDisplay : MonoBehaviour, ISkillGlowDisplay
    {
        private ISkillVisual _skillVisual;

        private void Awake()
        {
            _skillVisual = GetComponent<ISkillVisual>();
        }
        
        /// <summary>
        /// Shows the green skill glow when skill is available for use
        /// </summary>
        public void ShowGlow()
        {
            _skillVisual.FrameGlowImage.enabled = true;
            _skillVisual.FrameLight2D.enabled = true;
        }
        
        /// <summary>
        /// Hides the green skill glow when skill is available for use
        /// </summary>
        public void HideGlow()
        {
            _skillVisual.FrameGlowImage.enabled = false;
            _skillVisual.FrameLight2D.enabled = false;
        }





    }
}
