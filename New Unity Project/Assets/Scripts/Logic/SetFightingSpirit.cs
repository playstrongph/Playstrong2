using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's fighting spirit value and visual text
    /// </summary>
    public class SetFightingSpirit : MonoBehaviour, ISetFightingSpirit
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Set fighting spirit value 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void StartAction(int value)
        {
            _heroLogic.HeroAttributes.FightingSpirit = value;
        }

        
    }
}