using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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
    private List<GameObject> heroes = new List<GameObject>();
        
    /// <summary>
    /// Used to add hero objects in the living heroes
    /// for inspector troubleshooting purposes only
    /// </summary>
    public List<GameObject> HeroesList => heroes;
        
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