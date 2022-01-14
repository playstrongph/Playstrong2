using System.Collections.Generic;
using Animation;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.GameAnimationAssets
{
    public abstract class GameAnimationsAsset : ScriptableObject, IGameAnimationsAsset
    {

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IGameVisualEffects))]
        protected List<Object> gameVisualEffects;

        public List<IGameVisualEffects> GameVisualEffects
        {
            get
            {
                var visualEffects = new List<IGameVisualEffects>();
                foreach (var visualEffect in gameVisualEffects)
                {
                    visualEffects.Add(visualEffect as IGameVisualEffects);
                }
                return visualEffects;
            }
        }



        public virtual void PlayAnimation(IHero hero, int value)
        { }
        
        public virtual void PlayAnimation(IHero hero)
        { }

        public float AnimationDuration { get; set; } = 0;
    }
}
