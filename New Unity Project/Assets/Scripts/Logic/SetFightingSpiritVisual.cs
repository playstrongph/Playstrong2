using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's fighting spirit visual text
    /// </summary>
    public class SetFightingSpiritVisual : MonoBehaviour, ISetFightingSpiritVisual
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
        /// Sets the fighting spirit visual value
        /// </summary>
        /// <param name="value"></param>
        public void StartAction(int value)
        {
            SetVisualValue(value);
        }

        private void SetVisualValue(int value)
        {
            var heroLogic = _heroVisual.Hero.HeroLogic;
            
            //var fightingSpiritValue = heroLogic.HeroAttributes.FightingSpirit;
            var fightingSpiritValue = value;

            var fightingSpiritVisualValue = Mathf.Max(0, fightingSpiritValue);
            var hero = _heroVisual.Hero;

            _heroVisual.FightingSpiritVisual.Text.text = fightingSpiritVisualValue.ToString();
            
            //TODO: Remove "if" once hero visual initialization is completed
            if(_initialLoad > 0)
                TextAnimationAsset.PlayAnimation(hero.HeroVisual.FightingSpiritVisual.Text);
            
            if(fightingSpiritValue <=0)
                HideTextAndIcon();
            else
                ShowTextAndIcon();
            
            //TODO: Remove once hero visual initialization is completed
            _initialLoad = 100;
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