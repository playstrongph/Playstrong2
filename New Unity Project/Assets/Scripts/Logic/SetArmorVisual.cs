using System.Collections;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's armor visual text
    /// </summary>
    public class SetArmorVisual : MonoBehaviour, ISetArmorVisual
    {
        private IHeroVisual _heroVisual;
        
        /// <summary>
        /// Text animation asset
        /// </summary>
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject textAnimationAsset;

        private IGameAnimationsAsset TextAnimationAsset
        {
            get => textAnimationAsset as IGameAnimationsAsset;
            set => textAnimationAsset = value as ScriptableObject;
        }
        
        private void Awake()
        {
            _heroVisual = GetComponent<IHeroVisual>();
        }
        
        /// <summary>
        /// Sets the armor visual value
        /// </summary>
        public void StartAction(int value)
        {
            SetVisualValue(value);
        }

        private void SetVisualValue(int value)
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            var armorValue = heroLogic.HeroAttributes.Armor;

            var armorVisualValue = Mathf.Max(0, value);
            var hero = _heroVisual.Hero;
            
            _heroVisual.ArmorVisual.Text.text = armorVisualValue.ToString();
            
            //Also prevents animation during initialization 
            if(hero.HeroLogic.TakeDamage.ArmorDamage > 0 )
                TextAnimationAsset.PlayAnimation(hero.HeroVisual.ArmorVisual.Text);

            if(armorValue <=0)
                HideTextAndIcon();
            else
                ShowTextAndIcon();
        }

        private void HideTextAndIcon()
        {
            _heroVisual.ArmorVisual.Text.gameObject.SetActive(false);
            _heroVisual.ArmorVisual.Icon.gameObject.SetActive(false);
        }
        
        private void ShowTextAndIcon()
        {
            _heroVisual.ArmorVisual.Text.gameObject.SetActive(true);
            _heroVisual.ArmorVisual.Icon.gameObject.SetActive(true);
        }


    }
}