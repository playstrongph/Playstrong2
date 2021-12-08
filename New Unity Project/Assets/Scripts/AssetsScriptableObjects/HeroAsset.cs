using UnityEngine;

namespace AssetsScriptableObjects
{
    [CreateAssetMenu(fileName = "NewHero", menuName = "Assets/NewHero")]
    public class HeroAsset : ScriptableObject
    {   
        /// <summary>
        /// Hero's name.
        /// Set in the inspector 
        /// </summary>
        [Header("Hero Information")]
        [SerializeField]
        private string heroName;
        public string HeroName
        {
            get => heroName;
            private set => heroName = value;
        }
        
        /// <summary>
        /// Hero's class - Ranger, Warrior, Mage, etc.
        /// Set in the inspector 
        /// </summary>
        [SerializeField]
        private string heroClass;
        public string HeroClass
        {
            get => heroClass;
            private set => heroClass = value;
        }
        
        /// <summary>
        /// Hero's image
        /// </summary>
        [Header("Hero Graphic")] 
        [SerializeField]
        private Sprite heroSprite;

        public Sprite HeroSprite
        {
            get => heroSprite;
            private set => heroSprite = value;
        }
        
        /// <summary>
        /// Hero's health or life points
        /// </summary>
        [Header("Basic Hero Stats")] 
        [SerializeField]
        private int health;
        public int Health
        {
            get => health;
            private set => health = value;
        }
        
        /// <summary>
        /// Hero's attack power 
        /// </summary>
        [SerializeField]
        private int attack;
        public int Attack
        {
            get => attack;
            private set => attack = value;
        }
        
        /// <summary>
        /// Hero's speed  
        /// </summary>
        [SerializeField]
        private int speed;
        public int Speed
        {
            get => speed;
            private set => speed = value;
        }
        
        /// <summary>
        /// Hero's chance  
        /// </summary>
        [SerializeField]
        private int chance;
        public int Chance
        {
            get => chance;
            private set => chance = value;
        }
        
        /// <summary>
        /// Hero's armor  
        /// </summary>
        [SerializeField]
        private int armor;
        public int Armor
        {
            get => armor;
            private set => armor = value;
        }
        
        /// <summary>
        /// Hero's armor  
        /// </summary>
        [SerializeField]
        private int fightingSpirit;
        public int FightingSpirit
        {
            get => fightingSpirit;
            private set => fightingSpirit = value;
        }


    }
        
        








    }

