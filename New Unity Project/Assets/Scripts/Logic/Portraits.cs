using System.Collections.Generic;
using UnityEngine;


namespace Logic
{
    public class Portraits : MonoBehaviour, IPortraits
    {   
        /// <summary>
        /// Reference to portrait as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        /// <summary>
        /// Returns a list of hero portraits
        /// </summary>
        [SerializeField] private List<Object> heroPortraits = new List<Object>();
        public List<IHeroPortrait> HeroPortraits()
        {
            var portraits = new List<IHeroPortrait>();

            foreach (var heroPortraitObject in heroPortraits)
            {
                portraits.Add(heroPortraitObject as IHeroPortrait);
            }
            return portraits;
        }
    }
}
