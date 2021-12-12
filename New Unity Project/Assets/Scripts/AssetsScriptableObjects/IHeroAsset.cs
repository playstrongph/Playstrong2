using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace AssetsScriptableObjects
{
    public interface IHeroAsset
    {   
        /// <summary>
        /// Interface reference to hero name
        /// </summary>
        string HeroName { get; }
        
        /// <summary>
        /// Interface reference to hero class
        /// </summary>
        string HeroClass { get; }
        
        /// <summary>
        /// Interface access to hero sprite
        /// </summary>
        Sprite HeroSprite { get; }
        
        /// <summary>
        /// Interface access to health
        /// </summary>
        int Health { get; }
        
        /// <summary>
        /// Interface access to attack
        /// </summary>
        int Attack { get; }
        
        /// <summary>
        /// Interface access to speed
        /// </summary>
        int Speed { get; }
        
        /// <summary>
        /// Interface access to chance
        /// </summary>
        int Chance { get; }
        
        /// <summary>
        /// Interface access to armor
        /// </summary>
        int Armor { get; }
        
        /// <summary>
        /// Interface access to fighting spirit
        /// </summary>
        int FightingSpirit { get; }
        
        /// <summary>
        /// Reference to hero skill assets
        /// </summary>
        List<ISkill> HeroSkillAssets { get; }
    }
}