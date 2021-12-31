using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroTargetCollider : MonoBehaviour, IHeroTargetCollider
    {
        /// <summary>
        /// Reference to Hero where other
        /// components can be accessed
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object hero;
        public IHero Hero
        {
            get => hero as IHero;
            set => hero = value as Object;
        }

        [Header("SET IN RUNTIME")] [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object targetedHero;
        /// <summary>
        /// The last hero targeted by this hero
        /// </summary>
        public IHero TargetedHero
        {
            get => targetedHero as IHero;
            set => targetedHero = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object targetingHero;
        /// <summary>
        /// Last hero who targeted this hero
        /// </summary>
        public IHero TargetingHero
        {
            get => targetingHero as IHero;
            set => targetingHero = value as Object;
        }


        /// <summary>
        /// Reference to Display Hero Preview script
        /// </summary>
        public IDisplayHeroPreview DisplayHeroPreview { get; private set; }

        private void Awake()
        {
            DisplayHeroPreview = GetComponent<IDisplayHeroPreview>();
        }
    }
}