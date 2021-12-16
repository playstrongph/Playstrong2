using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


namespace Logic
{
    public class AliveHeroes : MonoBehaviour, IAliveHeroes
    {
        /// <summary>
        /// Reference to Player
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IPlayer))]
        private Object player;
        public IPlayer Player
        {
            get => player as IPlayer;
            private set => player = value as Object;
        }

        [Header("SET IN RUNTIME")] [SerializeField]
        private List<Object> livingHeroes = new List<Object>();
        
        /// <summary>
        /// Used to add hero objects in the living heroes
        /// for inspector troubleshooting purposes only
        /// </summary>
        public List<Object> LivingHeroesList => livingHeroes;
        
        /// <summary>
        /// Returns list of living heroes as IHero
        /// Do not directly add to this list
        /// </summary>
        public List<IHero> LivingHeroes
        {
            get
            {
                var heroes = new List<IHero>();
                foreach (var heroObject in livingHeroes)
                {
                    var hero = heroObject as IHero;
                    heroes.Add(hero);
                }
                return heroes;
            }
        }




        /// <summary>
        /// Gives access to currently displayed portrait and skills based on last hero selected by the player
        /// </summary>
        public IDisplayedPortraitAndSkills DisplayedPortraitAndSkills { get; private set; }

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        private void Awake()
        {
            DisplayedPortraitAndSkills = GetComponent<IDisplayedPortraitAndSkills>();
        }
    }
}
