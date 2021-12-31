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
        private Object targetHero;
        /// <summary>
        /// The last hero targeted by this hero
        /// </summary>
        public IHero TargetHero
        {
            get => targetHero as IHero;
            set => targetHero = value as Object;
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