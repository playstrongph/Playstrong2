using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Logic
{
    public class HeroLogic : MonoBehaviour, IHeroLogic
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

        /// <summary>
        /// Hero attributes reference
        /// </summary>
        public IHeroAttributes HeroAttributes { get; private set; }

        private void Awake()
        {
            HeroAttributes = GetComponent<IHeroAttributes>();
        }
    }
}
