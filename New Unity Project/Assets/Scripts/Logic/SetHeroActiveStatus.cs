using System;
using ScriptableObjectScripts.HeroActiveStatusAssets;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's active status to either hero active or hero inactive
    /// </summary>
    public class SetHeroActiveStatus : MonoBehaviour, ISetHeroActiveStatus
    {
        /// <summary>
        /// Generic active hero asset reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroActiveStatusAsset))] private ScriptableObject activeHeroAsset;

        private IHeroActiveStatusAsset ActiveHeroAsset
        {
            get => activeHeroAsset as IHeroActiveStatusAsset;
            set => activeHeroAsset = value as ScriptableObject;
        }

        /// <summary>
        /// Generic inactive hero asset reference
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroActiveStatusAsset))]private ScriptableObject inactiveHeroAsset;
        private IHeroActiveStatusAsset InactiveHeroAsset
        {
            get => inactiveHeroAsset as IHeroActiveStatusAsset;
            set => inactiveHeroAsset = value as ScriptableObject;
        }
        
        

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Sets the hero's active status to "ActiveHero" 
        /// </summary>
        public void ActiveHero()
        {
            _heroLogic.HeroActiveStatus = ActiveHeroAsset;
            
        }
        
        /// <summary>
        /// Sets the hero's active status to "InactiveHero"
        /// </summary>
        public void InactiveHero()
        {
            Debug.Log("Set Hero Inactive: " +_heroLogic.Hero.HeroName);
            _heroLogic.HeroActiveStatus = InactiveHeroAsset;
            
        }
        
        
        
        

    }
}
