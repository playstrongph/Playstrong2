using UnityEngine;

namespace Logic
{
    public class DisplayedPortraitAndSkills : MonoBehaviour, IDisplayedPortraitAndSkills
    {
        /// <summary>
        /// Current displayed heroPortrait
        /// </summary>
        public IHeroPortrait DisplayedHeroPortrait { get; set; }
        
        /// <summary>
        /// Current displayed hero skills 
        /// </summary>
        public IHeroSkills DisplayedHeroSkills { get; set; }


        private IAliveHeroes _aliveHeroes;

        private void Awake()
        {
            _aliveHeroes = GetComponent<IAliveHeroes>();
        }
    }
}