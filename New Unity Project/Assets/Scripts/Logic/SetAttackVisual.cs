using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's visual text
    /// </summary>
    public class SetAttackVisual : MonoBehaviour, ISetAttackVisual
    {
        private IHeroVisual _heroVisual;
        
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Sets the attack visual value
        /// </summary>
        public void StartAction()
        {
            SetVisualValue();
        }

        private void SetVisualValue()
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            var baseValue = heroLogic.HeroAttributes.BaseAttack;
            var attackValue = heroLogic.HeroAttributes.Attack;
            
            //Clamp minimum display value to zero
            var attackVisualValue = Mathf.Max(0, attackValue);
            
            _heroVisual.AttackVisual.Text.text = attackVisualValue.ToString();
            _heroVisual.AttackVisual.Text.color = GetTextColor(baseValue, attackValue);
        }
        
        private Color GetTextColor(int baseValue, int value)
        {
            if(value>baseValue)
                return Color.green;
            else if (value == baseValue)
                return Color.white;
            else if(value < baseValue)
                return Color.red;
            else
                return Color.white;
        }
    }
}