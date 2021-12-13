using System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Logic
{
    public class TargetCollider : MonoBehaviour, ITargetCollider
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
        /// Reference to Display Hero Preview script
        /// </summary>
        public IDisplayHeroPreview DisplayHeroPreview { get; private set; }

        private void Awake()
        {
            DisplayHeroPreview = GetComponent<IDisplayHeroPreview>();
        }
    }
}
