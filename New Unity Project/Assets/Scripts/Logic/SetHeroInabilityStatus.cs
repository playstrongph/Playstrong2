using ScriptableObjectScripts.HeroInabilityStatusAssets;
using UnityEngine;

namespace Logic
{
    public class SetHeroInabilityStatus : MonoBehaviour, ISetHeroInabilityStatus
    {   
        /// <summary>
        /// Generic has Inability Interface
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroInabilityStatusAsset))]
        private ScriptableObject hasInabilityAsset;

        private IHeroInabilityStatusAsset HasInabilityAsset
        {
            get => hasInabilityAsset as IHeroInabilityStatusAsset;
            set => hasInabilityAsset = value as ScriptableObject;
        }
        
        /// <summary>
        /// Generic No Inability Interface
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroInabilityStatusAsset))]
        private ScriptableObject noInabilityAsset;

        private IHeroInabilityStatusAsset NoInabilityAsset
        {
            get => noInabilityAsset as IHeroInabilityStatusAsset;
            set => noInabilityAsset = value as ScriptableObject;
        }
        
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Sets the hero inability status to "HasInability"
        /// </summary>
        public void HasInability()
        {
            _heroLogic.HeroInabilityStatus = HasInabilityAsset;
        }
        
        /// <summary>
        /// Sets the hero inability status to "NoInability"
        /// </summary>
        public void NoInability()
        {
            _heroLogic.HeroInabilityStatus = NoInabilityAsset;
        }

    }
}
