using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// SkillPreview reference 
    /// </summary>
    public class SkillTargetCollider : MonoBehaviour, ISkillTargetCollider
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
        /// Reference to skill target collider canvas
        /// </summary>
        [SerializeField] private Canvas targetCanvas;
        public Canvas TargetCanvas
        {
            get => targetCanvas;
            set => targetCanvas = value;
        }
        
        /// <summary>
        /// Reference to skill target cross hair
        /// </summary>
        [SerializeField] private GameObject crossHair;
        public GameObject CrossHair
        {
            get => crossHair;
            set => crossHair = value;
        }
        
        /// <summary>
        /// Reference to skill target triangle
        /// </summary>
        [SerializeField] private GameObject triangle;
        public GameObject Triangle
        {
            get => triangle;
            set => triangle = value;
        }

        /// <summary>
        /// Reference to skill target line renderer
        /// </summary>
        [SerializeField] private LineRenderer targetLine;
        public LineRenderer TargetLine
        {
            get => targetLine;
            set => targetLine = value;
        }
        
        /// <summary>
        /// Reference to display skill preview
        /// </summary>
        public IDisplaySkillPreview DisplaySkillPreview { get; private set; }
        
        
        /// <summary>
        /// Reference to select drag target
        /// </summary>
        public ISelectDragTarget SelectDragTarget { get; private set; }
        
        /// <summary>
        /// Reference to draggable component
        /// </summary>
        public IDraggable Draggable { get; private set; }
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        private void Awake()
        {
            DisplaySkillPreview = GetComponent<IDisplaySkillPreview>();
            SelectDragTarget = GetComponent<ISelectDragTarget>();
            Draggable = GetComponent<IDraggable>();
        }
    }
}