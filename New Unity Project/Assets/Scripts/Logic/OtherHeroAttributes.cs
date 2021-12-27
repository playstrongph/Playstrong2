using UnityEngine;

namespace Logic
{
    public class OtherHeroAttributes : MonoBehaviour, IOtherHeroAttributes
    {
        
        
        [Header("RESISTANCES")] [SerializeField ]private int targetAttackResistance;
        /// <summary>
        /// Value greater than zero means the hero can't be targeted directly by attack type skills.
        /// Used by stealth, taunt, and similar effects.
        /// </summary>
        public int AttackTargetAssistance
        {
            get => targetAttackResistance;
            set => targetAttackResistance = value;
        }
        
        


    }
}
