using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class ExtinctHeroes : MonoBehaviour, IExtinctHeroes
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
        private List<GameObject> heroes = new List<GameObject>();
        
        /// <summary>
        /// Provides access to heroes list as game objects 
        /// </summary>
        public List<GameObject> HeroesGameObjects => heroes;
        
        /// <summary>
        /// Returns list of living heroes as IHero
        /// Do not directly add to this list
        /// </summary>
        public List<IHero> Heroes
        {
            get
            {
                var newHeroes = new List<IHero>();
                foreach (var heroObject in heroes)
                {
                    var hero = heroObject.GetComponent<IHero>();
                    newHeroes.Add(hero);
                }
                return newHeroes;
            }
        }

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
      

        
    }
}