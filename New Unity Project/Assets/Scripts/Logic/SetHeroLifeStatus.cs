using System;
using ScriptableObjectScripts.HeroLifeStatusAssets;
using UnityEngine;

namespace Logic
{
    public class SetHeroLifeStatus : MonoBehaviour, ISetHeroLifeStatus
    {
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroLifeStatusAsset))]
        private ScriptableObject heroAliveStatusAsset;

        /// <summary>
        /// Hero alive status asset
        /// </summary>
        private IHeroLifeStatusAsset HeroAliveStatusAsset
        {
            get => heroAliveStatusAsset as IHeroLifeStatusAsset;
            set => heroAliveStatusAsset = value as ScriptableObject;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroLifeStatusAsset))]
        private ScriptableObject heroDeadStatusAsset;

        /// <summary>
        /// Hero dead status asset
        /// </summary>
        private IHeroLifeStatusAsset HeroDeadStatusAsset
        {
            get => heroDeadStatusAsset as IHeroLifeStatusAsset;
            set => heroDeadStatusAsset = value as ScriptableObject;
        }

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Sets the hero life status to hero alive
        /// </summary>
        public void HeroAlive()
        {
            _heroLogic.HeroLifeStatus = HeroAliveStatusAsset;
        }
        
        /// <summary>
        /// Sets the hero life status to hero alive
        /// </summary>
        public void HeroDead()
        {
            _heroLogic.HeroLifeStatus = HeroDeadStatusAsset;
        }
    }
}
