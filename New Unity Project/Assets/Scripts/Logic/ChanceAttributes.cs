using UnityEngine;

namespace Logic
{
    public class ChanceAttributes : MonoBehaviour, IChanceAttributes
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        [SerializeField] private int criticalChance;
        
        /// <summary>
        /// Probability for a hero to deal critical strike
        /// </summary>
        public int CriticalChance
        {
            get => criticalChance;
            set => criticalChance = value;
        }
    
    
    }
}
