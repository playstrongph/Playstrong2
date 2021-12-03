using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class HeroStatusEffects : MonoBehaviour, IHeroStatusEffects
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
        
    }
}
