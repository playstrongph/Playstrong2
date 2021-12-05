using UnityEngine;


namespace Logic
{
    public class Player : MonoBehaviour, IPlayer
    {
        
        /// <summary>
        /// Reference to AliveHeroes
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IAliveHeroes))]
        private Object aliveHeroes;
        public IAliveHeroes AliveHeroes
        {
            get => aliveHeroes as IAliveHeroes;
            set => aliveHeroes = value as Object;
        }
        
        /// <summary>
        /// Reference to dead heroes
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDeadHeroes))]
        private Object deadHeroes;
        public IDeadHeroes DeadHeroes
        {
            get => deadHeroes as IDeadHeroes;
            set => deadHeroes = value as Object;
        }

        /// <summary>
        /// Reference access to hero skills
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroSkills))]
        private Object heroSkills;

        public IHeroSkills HeroSkills
        {
            get => heroSkills as IHeroSkills;
            set => heroSkills = value as Object;
        }
        
        /// <summary>
        /// Reference access to portraits
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPortraits))]
        private Object portraits;
        public IPortraits Portraits
        {
            get => portraits as IPortraits;
            set => portraits = value as Object;
        }
        
        /// <summary>
        /// Reference access to display skills
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDisplaySkills))]
        private Object displaySkills;
        public IDisplaySkills DisplaySkills
        {
            get => displaySkills as IDisplaySkills;
            set => displaySkills = value as Object;
        }
        
        /// <summary>
        /// Reference access to display portraits
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IDisplayPortraits))]
        private Object displayPortraits;
        public IDisplayPortraits DisplayPortraits
        {
            get => displayPortraits as IDisplayPortraits;
            set => displayPortraits = value as Object;
        }
        
        



    }
}
