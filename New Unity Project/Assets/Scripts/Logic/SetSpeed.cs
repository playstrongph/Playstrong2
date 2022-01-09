using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's speed value and visual text
    /// </summary>
    public class SetSpeed : MonoBehaviour, ISetSpeed
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(int value)
        {
            _heroLogic.HeroAttributes.Speed = value;
        }

        


    }
}