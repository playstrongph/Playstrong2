using UnityEngine;
using Object = UnityEngine.Object;

namespace Logic
{
    public class HeroVisual : MonoBehaviour, IHeroVisual
    {

        /// <summary>
        /// Reference to Hero where other
        /// components can be accessed
        /// </summary>
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHero))]
        private Object hero;
        public IHero Hero
        {
            get => hero as IHero;
            private set => hero = value as Object;
        }
        
        [SerializeField] private Canvas heroGraphicCanvas;
        public Canvas HeroGraphicCanvas
        {
            get => heroGraphicCanvas;
            private set => heroGraphicCanvas = value;
        }

        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroFrameAndGlow))]private Object tauntFrame;
        public IHeroFrameAndGlow TauntFrame
        {
            get => tauntFrame as IHeroFrameAndGlow;
            private set => tauntFrame = value as Object;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IHeroFrameAndGlow))] private Object normalFrame;
        public IHeroFrameAndGlow NormalFrame
        {
            get => normalFrame as IHeroFrameAndGlow;
            private set => normalFrame = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IHeroGraphic))] private Object heroGraphic;
        public IHeroGraphic HeroGraphic
        {
            get => heroGraphic as IHeroGraphic;
            set => heroGraphic = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IAttackVisual))] private Object attackVisual;
        public IAttackVisual AttackVisual
        {
            get => attackVisual as IAttackVisual;
            set => attackVisual = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IHealthVisual))] private Object healthVisual;
        public IHealthVisual HealthVisual
        {
            get => healthVisual as IHealthVisual;
            set => healthVisual = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IArmorVisual))] private Object armorVisual;
        public IArmorVisual ArmorVisual
        {
            get => armorVisual as IArmorVisual;
            set => armorVisual = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IEnergyVisual))] private Object energyVisual;
        public IEnergyVisual EnergyVisual
        {
            get => energyVisual as IEnergyVisual;
            set => energyVisual = value as Object;
        }
        
        [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IFightingSpiritVisual))] private Object fightingSpiritVisual;
        public IFightingSpiritVisual FightingSpiritVisual
        {
            get => fightingSpiritVisual as IFightingSpiritVisual;
            set => fightingSpiritVisual = value as Object;
        }
        
        /// <summary>
        /// Loads the hero visual components
        /// </summary>
        public ILoadHeroVisuals LoadHeroVisuals { get; private set; }
        
        /// <summary>
        /// Returns the current hero frame and glow setting or change it
        /// to either Taunt or Normal frame.
        /// </summary>
        public ISetHeroFrameAndGlow SetHeroFrameAndGlow { get; private set; }
        
        /// <summary>
        /// Set the armor text
        /// Hide and show armor icon
        /// </summary>
        public ISetArmorVisual SetArmorVisual { get; private set; }
        
        /// <summary>
        /// Set the attack text and color
        /// </summary>
        public ISetAttackVisual SetAttackVisual { get; private set; }
        
        /// <summary>
        /// Set the health text and color
        /// </summary>
        public ISetHealthVisual SetHealthVisual { get; private set; }
        
        /// <summary>
        /// Set the fighting spirit, show and hide icon
        /// </summary>
        public ISetFightingSpiritVisual SetFightingSpiritVisual { get; private set; }
        
        /// <summary>
        /// Sets the energy text, fill, and color
        /// </summary>
        public ISetEnergyVisual SetEnergyVisual { get; private set; }
        
        /// <summary>
        /// Sets the energy text and fill color based on changes in speed
        /// </summary>
        public ISetSpeedVisual SetSpeedVisual { get; private set; }

        private void Awake()
        {
            LoadHeroVisuals = GetComponent<ILoadHeroVisuals>();
            SetHeroFrameAndGlow = GetComponent<ISetHeroFrameAndGlow>();
            SetArmorVisual = GetComponent<ISetArmorVisual>();
            SetAttackVisual = GetComponent<ISetAttackVisual>();
            SetHealthVisual = GetComponent<ISetHealthVisual>();
            SetFightingSpiritVisual = GetComponent<ISetFightingSpiritVisual>();
            SetEnergyVisual = GetComponent<ISetEnergyVisual>();
            SetSpeedVisual = GetComponent<ISetSpeedVisual>();
        }
    }
}