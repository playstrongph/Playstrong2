using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's health value and visual text
    /// </summary>
    public class SetHealth : MonoBehaviour, ISetHealth
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(int value)
        {
            //set attribute value
            _heroLogic.HeroAttributes.Health = value;
            
            _heroLogic.Hero.HeroVisual.SetHealthVisual.StartAction();
        }



    }
}