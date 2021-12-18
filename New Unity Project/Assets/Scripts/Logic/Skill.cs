using JondiBranchLogic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// Skill prefab reference 
    /// </summary>
    public class Skill : MonoBehaviour, ISkill
    {
        /// <summary>
        /// Reference to skill logic
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillLogic))]
        private Object skillLogic;
        
        public ISkillLogic SkillLogic
        {
            get => skillLogic as ISkillLogic;
            set => skillLogic = value as Object;
        }
        
        /// <summary>
        /// Reference to skill visual
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillVisual))]
        private Object skillVisual;
        
        public ISkillVisual SkillVisual
        {
            get => skillVisual as ISkillVisual;
            set => skillVisual = value as Object;
        }
        
        /// <summary>
        /// Reference to skill preview
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillPreview))]
        private Object skillPreview;
        
        public ISkillPreview SkillPreview
        {
            get => skillPreview as ISkillPreview;
            set => skillPreview = value as Object;
        }
        
        /// <summary>
        /// Reference to skill target collider
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkillTargetCollider))]
        private Object skillTargetCollider;
        
        public ISkillTargetCollider SkillTargetCollider
        {
            get => skillTargetCollider as ISkillTargetCollider;
            set => skillTargetCollider = value as Object;
        }
        
        /// <summary>
        /// Reference to coroutine trees 
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ICoroutineTreesAsset))]
        private Object coroutineTrees;
        
        public ICoroutineTreesAsset CoroutineTrees
        {
            get => coroutineTrees as ICoroutineTreesAsset;
            set => coroutineTrees = value as Object;
        }
        
        //SET IN RUNTIME


        [Header("SET IN RUNTIME")] [SerializeField]private string skillName;
        public string SkillName
        {
            get => skillName;
            set => skillName = value;
        }


        /// <summary>
        /// Reference to skill target collider
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object hero;
        
        public IHero Hero
        {
            get => hero as IHero;
            set => hero = value as Object;
        }
        
        
        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        



    }
}