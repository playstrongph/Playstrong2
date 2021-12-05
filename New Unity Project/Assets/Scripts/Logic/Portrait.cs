using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class Portrait : MonoBehaviour, IPortrait
    {
        /// <summary>
        /// Reference to portrait canvas.
        /// Set in the inspector.
        /// </summary>
        [SerializeField] private Canvas portraitCanvas;
        public Canvas PortraitCanvas
        {
            get => portraitCanvas;
            set => portraitCanvas = value;
        }
        
        /// <summary>
        /// Reference to portrait frame image.
        /// Set in the inspector.
        /// </summary>
        [SerializeField] private Image frameImage;
        public Image FrameImage
        {
            get => frameImage;
            set => frameImage = value;
        }
        
        /// <summary>
        /// Reference to portrait image.
        /// Set in the inspector.
        /// </summary>
        [SerializeField] private Image portraitImage;
        public Image PortraitImage
        {
            get => portraitImage;
            set => portraitImage = value;
        }

    }
}
