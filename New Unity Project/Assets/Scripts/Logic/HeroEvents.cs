using System;
using UnityEngine;

namespace Logic
{
    public class HeroEvents : MonoBehaviour
    {
        /// <summary>
        /// Hero event signature - only the casterHero is required
        /// </summary>
        public delegate void HeroEvent(IHero hero);

        #region EVENT DELEGATES

        public event HeroEvent EBeforeHeroSkillAttacks;
        public event HeroEvent EBeforeHeroIsSkillAttacked;
        
        
        

        #endregion

        #region EVENT CALLS
        
        /// <summary>
        /// Before caster hero skill attacks event
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroSkillAttacks(IHero hero)
        {
            EBeforeHeroSkillAttacks?.Invoke(hero);
        }
        
        /// <summary>
        /// Before targeted hero is attacked event
        /// </summary>
        /// <param name="hero"></param>
        public void EventEBeforeHeroIsSkillAttacked(IHero hero)
        {
            EBeforeHeroIsSkillAttacked?.Invoke(hero);
        }
        
        
        
        
        

        #endregion


        #region UNSUBSCRIBE EVENTS

        private void UnsubscribeEventBeforeHeroSkillAttacks()
        {
            var clients = EBeforeHeroSkillAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroSkillAttacks -= client as HeroEvent;
        }
        
        private void UnsubscribeEventEBeforeHeroIsSkillAttacked()
        {
            var clients = EBeforeHeroIsSkillAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsSkillAttacked -= client as HeroEvent;
        }
        
        

        #endregion
        



        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        /// <summary>
        /// Unsubscribe all event subscribers 
        /// </summary>
        private void OnDestroy()
        {
            UnsubscribeEventBeforeHeroSkillAttacks();
            UnsubscribeEventEBeforeHeroIsSkillAttacked();
        }
    }
}
