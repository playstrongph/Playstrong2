using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class SetHeroFrameAndGlow : MonoBehaviour, ISetHeroFrameAndGlow
    {
        /// <summary>
        /// Returns the current frame and glows in use - can be either normal or taunt
        /// default setting is normal frame
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroFrameAndGlow))]
        private Object currentHeroFrame;
        public IHeroFrameAndGlow CurrentHeroFrame
        {
            get => currentHeroFrame as IHeroFrameAndGlow;
            set => currentHeroFrame = value as Object;
        }

        private IHeroVisual _heroVisual;
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }

        /// <summary>
        /// Taunt setting for the current hero frame and glows
        /// </summary>
        public void SetTauntFrame()
        {
            var tauntFrame = _heroVisual.TauntFrame;
            CurrentHeroFrame = tauntFrame;
        }
        
        /// <summary>
        /// Normal setting for the current hero frame and glows
        /// </summary>
        public void SetNormalFrame()
        {
            var normalFrame = _heroVisual.NormalFrame;
            CurrentHeroFrame = normalFrame;
        }



    }
}
