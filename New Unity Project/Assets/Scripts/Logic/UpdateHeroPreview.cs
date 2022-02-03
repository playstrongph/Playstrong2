using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public class UpdateHeroPreview : MonoBehaviour, IUpdateHeroPreview
    {
        private IHeroPreview _heroPreview;

        private void Awake()
        {
            _heroPreview = GetComponent<IHeroPreview>();
        }
        
        /// <summary>
        /// Updates the values of the hero preview's basic attributes
        /// </summary>
        public void StartAction()
        {
            var heroAttributes = _heroPreview.Hero.HeroLogic.HeroAttributes;
            
            var baseAttack = heroAttributes.BaseAttack;
            var baseHealth = heroAttributes.BaseHealth;
            var baseSpeed = heroAttributes.BaseSpeed;
            var baseChance = heroAttributes.BaseChance;
            var attack = heroAttributes.Attack;
            var health = heroAttributes.Health;
            var speed = heroAttributes.Speed;
            var chance = heroAttributes.Chance;


            //BASE BASIC ATTRIBUTES
            
            //update preview attack text and color
            _heroPreview.HeroPreviewAttack.PreviewText.text = attack.ToString();
            SetTextColor(baseAttack,attack,_heroPreview.HeroPreviewAttack.PreviewText);
            
            //update preview health text and color
            _heroPreview.HeroPreviewHealth.PreviewText.text = health.ToString();
            SetTextColor(baseHealth, health, _heroPreview.HeroPreviewHealth.PreviewText);
            
            //update preview speed text and color
            _heroPreview.HeroPreviewSpeed.PreviewText.text = speed.ToString();
            SetTextColor(baseSpeed,speed, _heroPreview.HeroPreviewSpeed.PreviewText);
            
            //update preview chance text and color
            _heroPreview.HeroPreviewChance.PreviewText.text = chance.ToString();
            SetTextColor(baseChance,chance, _heroPreview.HeroPreviewChance.PreviewText);
            
        }
        
        private void SetTextColor(int baseValue, int value, TextMeshProUGUI text)
        {
            if(value>baseValue)
                text.color = Color.green;
            else if (value == baseValue)
                text.color = Color.white;
            else if(value < baseValue)
                text.color = Color.red;
            else
                text.color = Color.white;
        }
    }
}