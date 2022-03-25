namespace Logic
{
    public interface IHeroEvents
    {
        #region EVENT DELEGATES

        event HeroEvents.HeroesEvent EBeforeHeroSkillAttacks;
        event HeroEvents.HeroesEvent EBeforeHeroIsSkillAttacked;
        event HeroEvents.HeroesEvent EBeforeHeroAttacks;
        event HeroEvents.HeroesEvent EBeforeHeroIsAttacked;
        event HeroEvents.HeroesEvent EAfterHeroAttacks;
        event HeroEvents.HeroesEvent EAfterHeroIsAttacked;
        event HeroEvents.HeroesEvent EAfterHeroSkillAttacks;
        event HeroEvents.HeroesEvent EAfterHeroIsSkillAttacked;
        event HeroEvents.HeroesEvent EBeforeHeroCriticalStrikes;
        event HeroEvents.HeroesEvent EBeforeHeroIsDealtCriticalStrike;
        event HeroEvents.HeroesEvent EAfterHeroIsDealtCriticalStrike;
        event HeroEvents.HeroesEvent EAfterHeroDealsCriticalStrike;
        event HeroEvents.HeroesEvent EBeforeHeroCounterAttacks;
        event HeroEvents.HeroesEvent EBeforeHeroIsCounterAttacked;
        event HeroEvents.HeroesEvent EAfterHeroCounterAttacks;
        event HeroEvents.HeroesEvent EAfterHeroIsCounterAttacked;
        event HeroEvents.HeroesEvent EBeforeHeroDealsSkillDamage;
        event HeroEvents.HeroesEvent EBeforeHeroTakesSkillDamage;
        event HeroEvents.HeroesEvent EAfterHeroDealsSkillDamage;
        event HeroEvents.HeroesEvent EAfterHeroTakesSkillDamage;
        event HeroEvents.HeroEvent EBeforeHeroTakesNonSkillDamage;
        event HeroEvents.HeroEvent EAfterHeroTakesNonSkillDamage;
        event HeroEvents.HeroEvent EBeforeHeroDealsSingleTargetAttack;
        event HeroEvents.HeroEvent EBeforeHeroTakesSingleTargetAttack;
        event HeroEvents.HeroEvent EAfterHeroDealsSingleTargetAttack;
        event HeroEvents.HeroEvent EAfterHeroTakesSingleTargetAttack;
        event HeroEvents.HeroEvent EBeforeHeroTakesMultiTargetAttack;
        event HeroEvents.HeroEvent EBeforeHeroDealsMultiTargetAttack;
        event HeroEvents.HeroEvent EAfterHeroDealsMultiTargetAttack;
        event HeroEvents.HeroEvent EAfterHeroTakesMultiTargetAttack;
        event HeroEvents.HeroEvent EAfterHeroEndTurn;
        event HeroEvents.HeroEvent EBeforeHeroStartTurn;
        event HeroEvents.HeroEvent EHeroTakesFatalDamage;
        event HeroEvents.HeroEvent EHeroDies;
        event HeroEvents.HeroEvent EPostHeroDeath;

        #endregion


        #region EVENT CALLS

        /// <summary>
        /// Before caster hero skill attacks 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroSkillAttacks(IHero casterHero, IHero targetHero);

        /// <summary>
        /// Before targeted hero is attacked 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventEBeforeHeroIsSkillAttacked(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Before the caster hero attacks
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void EventBeforeHeroAttacks(IHero casterHero, IHero targetHero);

        /// <summary>
        /// Before the targeted hero is attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroIsAttacked(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// After the caster hero attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventAfterHeroAttacks(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// After the hero is attacked
        /// </summary>
        /// / <param name="casterHero"></param>
        /// / <param name="targetHero"></param>
        void EventAfterHeroIsAttacked(IHero casterHero,IHero targetHero);
        
        /// <summary>
        /// After the hero skill attacks
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void EventAfterHeroSkillAttacks(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After the targeted hero is skill attacked
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void EventAfterHeroIsSkillAttacked(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Before the caster hero deals critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void EventBeforeHeroCriticalStrikes(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Before the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroIsDealtCriticalStrike(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventAfterHeroIsDealtCriticalStrike(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After the caster hero deals critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventAfterHeroDealsCriticalStrike(IHero casterHero,IHero targetHero);

        /// <summary>
        ///  Before the hero counter attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroCounterAttacks(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// Before the hero is counter attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroIsCounterAttacked(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After the hero counter attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventAfterHeroCounterAttacks(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After the hero is counter attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventAfterHeroIsCounterAttacked(IHero casterHero, IHero targetHero);

        /// <summary>
        /// Before hero deals attack skill damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroDealsSkillDamage(IHero casterHero, IHero targetHero);

        /// <summary>
        /// Before hero takes skill damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventBeforeHeroTakesSkillDamage(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After hero deals skill damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        void EventAfterHeroDealsSkillDamage(IHero casterHero, IHero targetHero);
        
        /// <summary>
        /// After hero takes skill damage
        /// </summary>
        ///  <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        void EventAfterHeroTakesSkillDamage(IHero casterHero,IHero targetHero);

        /// <summary>
        /// Before hero takes damage from a non-hero source (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroTakesNonSkillDamage(IHero hero);

        /// <summary>
        /// After a hero takes damage from a non-hero source (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroTakesNonSkillDamage(IHero hero);
        
        /// <summary>
        /// Before hero deals single target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroDealsSingleTargetAttack(IHero hero);
        
        /// <summary>
        /// Before hero takes single target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroTakesSingleTargetAttack(IHero hero);
        
        /// <summary>
        /// After hero deals single target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroDealsSingleTargetAttack(IHero hero);
        
        /// <summary>
        /// After hero takes single target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroTakesSingleTargetAttack(IHero hero);
        
        /// <summary>
        /// Before hero takes multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroTakesMultiTargetAttack(IHero hero);
        
        /// <summary>
        /// Before hero deals multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroDealsMultiTargetAttack(IHero hero);
        
        /// <summary>
        /// After hero deals multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroDealsMultiTargetAttack(IHero hero);
        
        /// <summary>
        /// After hero takes multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroTakesMultiTargetAttack(IHero hero);
        
        /// <summary>
        /// After hero end turn (different from hero end turn event)
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroEndTurn(IHero hero);
        
        /// <summary>
        /// Before hero start turn (different from hero end turn event)
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroStartTurn(IHero hero);
        
        /// <summary>
        /// When hero takes fatal damage, before hero dies
        /// </summary>
        /// <param name="hero"></param>
        void EventHeroTakesFatalDamage(IHero hero);
        
        /// <summary>
        /// When the hero dies event
        /// </summary>
        /// <param name="hero"></param>
        void EventHeroDies(IHero hero);
        
        void EventPostHeroDeath(IHero hero);

        #endregion
    }
}