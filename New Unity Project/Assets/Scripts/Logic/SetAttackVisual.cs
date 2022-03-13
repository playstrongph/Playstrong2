using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's visual text
    /// </summary>
    public class SetAttackVisual : MonoBehaviour, ISetAttackVisual
    {
        private IHeroVisual _heroVisual;
        
        //TODO: Temporary, remove once hero display delay is implemented in hero initialization
        private int _initialLoad = 0;

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
       /// Sets attack text value
       /// </summary>
       /// <param name="value"></param>
        public void StartAction(int value)
       {
           SetVisualValue(value);
       }

        private void SetVisualValue(int value)
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            var baseValue = heroLogic.HeroAttributes.BaseAttack;
            var attackValue = value;
            var hero = _heroVisual.Hero;
            var attackVisualValue = Mathf.Max(0, attackValue);

            _heroVisual.AttackVisual.Text.text = attackVisualValue.ToString();
            _heroVisual.AttackVisual.Text.color = GetTextColor(baseValue, attackValue);
            
            //TODO: Remove "if" once hero visual initialization is completed
            if(_initialLoad > 0)
                TextAnimationAsset.PlayAnimation(hero.HeroVisual.AttackVisual.Text);

            //TODO: Remove once hero visual initialization is completed
            _initialLoad = 100;
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