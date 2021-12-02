using UnityEngine;


namespace Logic
{
    public class HeroVisual : MonoBehaviour, IHeroVisual
    {

        [SerializeField] private Canvas heroCanvas;
        public Canvas HeroCanvas
        {
            get => heroCanvas;
            set => heroCanvas = value;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(ITauntFrame))]private Object tauntFrame;
        public ITauntFrame TauntFrame
        {
            get => tauntFrame as ITauntFrame;
            set => tauntFrame = value as Object;
        }
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(INormalFrame))] private Object normalFrame;
        public INormalFrame NormalFrame
        {
            get => normalFrame as INormalFrame;
            set => normalFrame = value as Object;
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
        
        
    }

    
}
