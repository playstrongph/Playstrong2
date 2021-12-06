using System;
using Logic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableObjectScripts
{
    [CreateAssetMenu(fileName = "BattleSceneSettings", menuName = "Assets/BattleSceneGeneral/BattleSceneSettings")]
    public class BattleSceneSettingsAsset : ScriptableObject, IBattleSceneSettingsAsset
    {
        /// <summary>
        /// Reference to player prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPlayer))]
        private Object playerPrefab;
        public IPlayer PlayerPrefab
        {
            get => playerPrefab as IPlayer;
            private set => playerPrefab = value as Object;
        }
        
        /// <summary>
        /// Reference to hero prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object heroPrefab;
        public IHero HeroPrefab
        {
            get => heroPrefab as IHero;
            private set => heroPrefab = value as Object;
        }
        
        /// <summary>
        /// Reference to skill prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ISkill))]
        private Object skillPrefab;
        public ISkill SkillPrefab
        {
            get => skillPrefab as ISkill;
            private set => skillPrefab = value as Object;
        }
        
        /// <summary>
        /// Reference to hero skills prefab
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroSkills))]
        private Object heroSkills;
        public IHeroSkills HeroSkills
        {
            get => heroSkills as IHeroSkills;
            private set => heroSkills = value as Object;
        }
        
        /// <summary>
        /// Reference to portrait
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPortrait))]
        private Object heroPortrait;
        public IPortrait HeroPortrait
        {
            get => heroPortrait as IPortrait;
            private set => heroPortrait = value as Object;
        }
        
        
        
        
        


        /// <summary>
        /// Reference to battle scene manager 
        /// </summary>
        [Header("SET IN RUNTIME")]
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IBattleSceneManager))]
        private Object battleSceneManager;
        public IBattleSceneManager BattleSceneManager
        {
            get => battleSceneManager as IBattleSceneManager;
            set => battleSceneManager = value as Object;
        }

        
    }
}
