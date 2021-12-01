using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    /// <summary>
    /// Hero prefab reference 
    /// </summary>
    public class Hero : MonoBehaviour, IHero
    {
        /// <summary>
        /// HeroLogic Reference
        /// Set not used but is scripted to avoid null warnings
        /// </summary>
        [Header("SET IN INSPECTOR")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroLogic))]
        private Object heroLogic;
        public IHeroLogic HeroLogic
        {
            get => heroLogic as IHeroLogic;
            set => heroLogic = value as Object;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroVisual))]
        private Object heroVisual;
        public IHeroVisual HeroVisual
        {
            get => heroVisual as IHeroVisual;
            set => heroVisual = value as Object;
        }
        
        
        
        
        
        
        
        
        
        
        /// <summary>
        /// TODO: To be recoded to return list of heroSkills
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroSkills))]
        private Object heroSkills;
        public IHeroSkills HeroSkills
        {
            get => heroSkills as IHeroSkills;
            set => heroSkills = value as Object;
        }
        
        /// <summary>
        /// TODO: To be recoded to return list of statusEffects
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffects))]
        private Object statusEffects;
        public IStatusEffects StatusEffects
        {
            get => statusEffects as IStatusEffects;
            set => statusEffects = value as Object;
        }
        
        



    }
}
