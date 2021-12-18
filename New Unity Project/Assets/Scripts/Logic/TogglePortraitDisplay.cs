using UnityEngine;

namespace Logic
{
    public class TogglePortraitDisplay : MonoBehaviour, ITogglePortraitDisplay
    {
        private IHeroPortrait _portrait;

        private void Awake()
        {
            _portrait = GetComponent<IHeroPortrait>();
        }
        
        /// <summary>
        /// Shows hero portrait
        /// </summary>
        public void ShowPortrait()
        {
            _portrait.PortraitCanvas.enabled = true;
        }
        
        /// <summary>
        /// Hides hero portrait
        /// </summary>
        public void HidePortrait()
        {
            _portrait.PortraitCanvas.enabled = false;
        }
    }
}