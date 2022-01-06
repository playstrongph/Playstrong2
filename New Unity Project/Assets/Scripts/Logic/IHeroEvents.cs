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

        #endregion
    }
}