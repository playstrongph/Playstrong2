using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's fighting spirit visual text
    /// </summary>
    public class SetFightingSpiritVisual : MonoBehaviour, ISetFightingSpiritVisual
    {
        private IHeroVisual _heroVisual;
        
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Sets the fighting spirit visual value
        /// </summary>
        public void StartAction()
        {
            SetVisualValue();
        }

        private void SetVisualValue()
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            var fightingSpiritValue = heroLogic.HeroAttributes.FightingSpirit;

            var fightingSpiritVisualValue = Mathf.Max(0, fightingSpiritValue);

            _heroVisual.FightingSpiritVisual.Text.text = fightingSpiritVisualValue.ToString();
            
            if(fightingSpiritValue <=0)
                HideTextAndIcon();
            else
                ShowTextAndIcon();
        }
        
        private void HideTextAndIcon()
        {
            _heroVisual.FightingSpiritVisual.Text.gameObject.SetActive(false);
            _heroVisual.FightingSpiritVisual.Icon.gameObject.SetActive(false);
        }
        
        private void ShowTextAndIcon()
        {
            _heroVisual.FightingSpiritVisual.Text.gameObject.SetActive(true);
            _heroVisual.FightingSpiritVisual.Icon.gameObject.SetActive(true);
        }

    }
}