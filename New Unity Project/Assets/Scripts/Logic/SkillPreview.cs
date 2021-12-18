using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// SkillPreview reference 
    /// </summary>
    public class SkillPreview : MonoBehaviour, ISkillPreview
    {
        /// <summary>
        /// Reference to skill 
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkill))]
        private Object skill;
        public ISkill Skill
        {
            get => skill as ISkill;
            set => skill = value as Object;
        }
        
        /// <summary>
        /// Reference to skill preview canvas
        /// </summary>
        [SerializeField] private Canvas previewCanvas;
        public Canvas PreviewCanvas
        {
            get => previewCanvas;
            set => previewCanvas = value;
        }

        /// <summary>
        /// Reference to frame Image
        /// </summary>
        [SerializeField] private Image frameImage;
        public Image FrameImage
        {
            get => frameImage;
            set => frameImage = value;
        }
        
        /// <summary>
        /// Reference to the skill previews' graphic Image
        /// </summary>
        [SerializeField] private Image graphicImage;
        public Image GraphicImage
        {
            get => graphicImage;
            set => graphicImage = value;
        }
        
        /// <summary>
        /// Reference to skill preview cooldown
        /// </summary>
        [SerializeField] private TextMeshProUGUI cooldown;
        public TextMeshProUGUI Cooldown
        {
            get => cooldown;
            set => cooldown = value;
        }
        
        /// <summary>
        /// Reference to skill preview name
        /// </summary>
        [SerializeField] private TextMeshProUGUI previewName;
        public TextMeshProUGUI PreviewName
        {
            get => previewName;
            set => previewName = value;
        }
        
        /// <summary>
        /// Reference to skill preview name
        /// </summary>
        [SerializeField] private TextMeshProUGUI description;
        public TextMeshProUGUI Description
        {
            get => description;
            set => description = value;
        }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// Loads the skill preview details and sets the board location
        /// </summary>
        public ILoadSkillPreviewVisual LoadSkillPreviewVisual { get; private set; }

        private void Awake()
        {
            LoadSkillPreviewVisual = GetComponent<ILoadSkillPreviewVisual>();
        }
    }
}