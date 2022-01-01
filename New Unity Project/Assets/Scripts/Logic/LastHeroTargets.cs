using UnityEngine;

namespace Logic
{   
    /// <summary>
    /// Targeting and Targeted heroes used in hero events
    /// </summary>
    public class LastHeroTargets : MonoBehaviour, ILastHeroTargets
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        [Header("SET IN RUNTIME")] [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object targetedHero;
        /// <summary>
        /// The last hero targeted by this hero
        /// </summary>
        public IHero TargetedHero
        {
            get => targetedHero as IHero;
            private set => targetedHero = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object targetingHero;
        /// <summary>
        /// Last hero who targeted this hero
        /// </summary>
        public IHero TargetingHero
        {
            get => targetingHero as IHero;
            private set => targetingHero = value as Object;
        }
        
        /// <summary>
        /// Set targeted hero 
        /// </summary>
        /// <param name="hero"></param>
        public void SetTargetedHero(IHero hero)
        {
            TargetedHero = hero;
        }
        
        /// <summary>
        /// Set targeting hero
        /// </summary>
        /// <param name="hero"></param>
        public void SetTargetingHero(IHero hero)
        {
            TargetingHero = hero;
        }
    }
}
