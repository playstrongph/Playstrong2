using System;
using AssetsScriptableObjects;
using JetBrains.Annotations;
using ScriptableObjectScripts;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// SkillVisual reference 
    /// </summary>
    public class SkillVisual : MonoBehaviour, ISkillVisual
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
        /// Reference to skill canvas
        /// </summary>
        [SerializeField]
        private Canvas skillCanvas;
        
        public Canvas SkillCanvas
        {
            get => skillCanvas;
            set => skillCanvas = value;
        }
        
        /// <summary>
        /// Reference to the frames' glow image component
        /// </summary>
        [SerializeField] private Image frameGlowImage;
        public Image FrameGlowImage
        {
            get => frameGlowImage;
            set => frameGlowImage = value;
        }
        
        /// <summary>
        /// Reference to the glow light 2D component
        /// </summary>
        [SerializeField] private Light2D frameLight2D;
        public Light2D FrameLight2D
        {
            get => frameLight2D;
            set => frameLight2D = value;
        }
        
        /// <summary>
        /// Reference to the frames' graphic image
        /// </summary>
        [SerializeField] private Image frameGraphic;
        public Image FrameGraphic
        {
            get => frameGraphic;
            set => frameGraphic = value;
        }
        
        /// <summary>
        /// Reference to the skill graphic image
        /// </summary>
        [SerializeField] private Image skillGraphic;
        public Image SkillGraphic
        {
            get => skillGraphic;
            set => skillGraphic = value;
        }
        
        /// <summary>
        /// Reference to the skill cooldown image
        /// </summary>
        [SerializeField] private Image cooldownIcon;
        public Image CooldownIcon
        {
            get => cooldownIcon;
            set => cooldownIcon = value;
        }

        /// <summary>
        /// Reference to the skill cooldown text
        /// </summary>
        [SerializeField] private TextMeshProUGUI cooldownText;
        public TextMeshProUGUI CooldownText
        {
            get => cooldownText;
            set => cooldownText = value;
        }
        
        /// <summary>
        /// Reference to load skill visuals
        /// </summary>
        public ILoadSkillVisual LoadSkillVisual { get; private set; }

        private void Awake()
        {
            LoadSkillVisual = GetComponent<ILoadSkillVisual>();
        }
    }
}
