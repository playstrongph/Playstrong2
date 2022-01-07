namespace Logic
{
    public interface IHeroEvents
    {
        #region EVENT DELEGATES

        event HeroEvents.HeroEvent EBeforeHeroSkillAttacks;
        event HeroEvents.HeroEvent EBeforeHeroIsSkillAttacked;
        event HeroEvents.HeroEvent EBeforeHeroAttacks;
        event HeroEvents.HeroEvent EBeforeHeroIsAttacked;
        event HeroEvents.HeroEvent EAfterHeroAttacks;
        event HeroEvents.HeroEvent EAfterHeroIsAttacked;
        event HeroEvents.HeroEvent EAfterHeroSkillAttacks;
        event HeroEvents.HeroEvent EAfterHeroIsSkillAttacked;
        event HeroEvents.HeroEvent EBeforeHeroCriticalStrikes;
        event HeroEvents.HeroEvent EBeforeHeroIsDealtCriticalStrike;
        event HeroEvents.HeroEvent EAfterHeroIsDealtCriticalStrike;
        event HeroEvents.HeroEvent EAfterHeroDealsCriticalStrike;
        event HeroEvents.HeroEvent EBeforeHeroDealsSkillDamage;
        event HeroEvents.HeroEvent EAfterHeroDealsSkillDamage;
        event HeroEvents.HeroEvent EBeforeDealingNonSkillDamage;
        event HeroEvents.HeroEvent EAfterDealingNonSkillDamage;
        
        
        
        #endregion


        #region EVENT CALLS

        /// <summary>
        /// Before caster hero skill attacks 
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroSkillAttacks(IHero hero);

        /// <summary>
        /// Before targeted hero is attacked 
        /// </summary>
        /// <param name="hero"></param>
        void EventEBeforeHeroIsSkillAttacked(IHero hero);
        
        /// <summary>
        /// Before the caster hero attacks
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroAttacks(IHero hero);

        /// <summary>
        /// Before the targeted hero is attacked
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroIsAttacked(IHero hero);
        
        /// <summary>
        /// After the caster hero attacks
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroAttacks(IHero hero);
        
        /// <summary>
        /// After the hero is attacked
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroIsAttacked(IHero hero);
        
        /// <summary>
        /// After the hero skill attacks
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroSkillAttacks(IHero hero);
        
        /// <summary>
        /// After the targeted hero is skill attacked
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroIsSkillAttacked(IHero hero);
        
        /// <summary>
        /// Before the caster hero deals critical strike
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroCriticalStrikes(IHero hero);
        
        /// <summary>
        /// Before the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroIsDealtCriticalStrike(IHero hero);
        
        /// <summary>
        /// After the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroIsDealtCriticalStrike(IHero hero);
        
        /// <summary>
        /// After the caster hero deals critical strike
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroDealsCriticalStrike(IHero hero);
        
        /// <summary>
        /// Before hero deals skill damage
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeHeroDealsSkillDamage(IHero hero);
        
        /// <summary>
        /// After hero deals skill damage
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterHeroDealsSkillDamage(IHero hero);
        
        /// <summary>
        /// Before a non-hero source deals damage (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        void EventBeforeDealingNonSkillDamage(IHero hero);
        
        /// <summary>
        ///  After a non-hero source deals damage (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        void EventAfterDealingNonSkillDamage(IHero hero);

        #endregion
    }
}