using UnityEngine;

namespace Logic
{
    public class HeroAttributes : MonoBehaviour, IHeroAttributes
    {   
        /// <summary>
        /// Hero logic reference
        /// </summary>
        private IHeroLogic heroLogic;
        
        /// <summary>
        /// Hero current attack
        /// </summary>
        [SerializeField] private int attack;
        public int Attack
        {
            get => attack;
            set => attack = value;
        }
        
        /// <summary>
        /// Hero current health
        /// </summary>
        [SerializeField] private int health;

        public int Health
        {
            get => health;
            set => health = value;
        }
        
        /// <summary>
        /// Hero current armor
        /// </summary>
        [SerializeField] private int armor;

        public int Armor
        {
            get => armor;
            set => armor = value;
        }
        
        /// <summary>
        /// Hero current speed
        /// </summary>
        [SerializeField] private int speed;

        public int Speed
        {
            get => speed;
            set => speed = value;
        }
        
        /// <summary>
        /// Hero current chance
        /// </summary>
        [SerializeField] private int chance;

        public int Chance
        {
            get => chance;
            set => chance = value;
        }
        
          
        /// <summary>
        /// Hero current energy
        /// </summary>
        [SerializeField] private int energy;

        public int Energy
        {
            get => energy;
            set => energy = value;
        }
        
        /// <summary>
        /// Hero current fightingEnergy
        /// </summary>
        [SerializeField] private int fightingSpirit;

        public int FightingSpirit
        {
            get => fightingSpirit;
            set => fightingSpirit = value;
        }
        
        
        
        /// <summary>
        /// Hero base Attack
        /// </summary>
        [Header("BASE VALUES ")]
        [SerializeField] private int baseAttack;
        public int BaseAttack
        {
            get => baseAttack;
            set => baseAttack = value;
        }
        
        /// <summary>
        /// Hero base health
        /// </summary>
        [SerializeField] private int baseHealth;
        public int BaseHealth
        {
            get => baseHealth;
            set => baseHealth = value;
        }
        
        /// <summary>
        /// Hero base armor
        /// </summary>
        [SerializeField] private int baseArmor;
        public int BaseArmor
        {
            get => baseArmor;
            set => baseArmor = value;
        }
        
        /// <summary>
        /// Hero base speed
        /// </summary>
        [SerializeField] private int baseSpeed;
        public int BaseSpeed
        {
            get => baseSpeed;
            set => baseSpeed = value;
        }
        
        /// <summary>
        /// Hero base chance
        /// </summary>
        [SerializeField] private int baseChance;
        public int BaseChance
        {
            get => baseChance;
            set => baseChance = value;
        }
        
        /// <summary>
        /// Passive values
        /// </summary>
        [Header("PASSIVE VALUES")] [SerializeField]
        private int passiveAttack;
        public int PassiveAttack
        {
            get => passiveAttack;
            set => passiveAttack = value;
        }



        private void Awake()
        {
            heroLogic = GetComponent<IHeroLogic>();
        }
        
    }
}