using System;
using UnityEngine;

namespace Logic
{
    public class HeroEvents : MonoBehaviour, IHeroEvents
    {
        /// <summary>
        /// Hero event signature - only the casterHero is required
        /// </summary>
        public delegate void HeroEvent(IHero hero);

        #region EVENT DELEGATES

        public event HeroEvent EBeforeHeroSkillAttacks;
        public event HeroEvent EBeforeHeroIsSkillAttacked;
        public event HeroEvent EBeforeHeroAttacks;
        public event HeroEvent EBeforeHeroIsAttacked;
        public event HeroEvent EAfterHeroAttacks;
        public event HeroEvent EAfterHeroIsAttacked;
        public event HeroEvent EAfterHeroSkillAttacks;
        public event HeroEvent EAfterHeroIsSkillAttacked;
        public event HeroEvent EBeforeHeroCriticalStrikes;
        public event HeroEvent EBeforeHeroIsDealtCriticalStrike;
        public event HeroEvent EAfterHeroIsDealtCriticalStrike;
        public event HeroEvent EAfterHeroDealsCriticalStrike;


        #endregion

        #region EVENT CALLS
        
        /// <summary>
        /// Before caster hero skill attacks 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroSkillAttacks(IHero hero)
        {
            EBeforeHeroSkillAttacks?.Invoke(hero);
        }
        
        /// <summary>
        /// Before targeted hero is attacked 
        /// </summary>
        /// <param name="hero"></param>
        public void EventEBeforeHeroIsSkillAttacked(IHero hero)
        {
            EBeforeHeroIsSkillAttacked?.Invoke(hero);
        }
        
        /// <summary>
        /// Before the caster hero attacks
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroAttacks(IHero hero)
        {
            EBeforeHeroAttacks?.Invoke(hero);
        }
        
        /// <summary>
        /// Before the targeted hero is attacked
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroIsAttacked(IHero hero)
        {
            EBeforeHeroIsAttacked?.Invoke(hero);
        }
        
        /// <summary>
        /// After the caster hero attacks
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroAttacks(IHero hero)
        {
            EAfterHeroAttacks?.Invoke(hero);
        }
        
        /// <summary>
        /// After the targeted hero
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroIsAttacked(IHero hero)
        {
            EAfterHeroIsAttacked?.Invoke(hero);
        }
        
        /// <summary>
        /// After the caster hero skill attacks
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroSkillAttacks(IHero hero)
        {
            EAfterHeroSkillAttacks?.Invoke(hero);
        }
        
        /// <summary>
        /// After the targeted hero is skill attacked
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroIsSkillAttacked(IHero hero)
        {
            EAfterHeroIsSkillAttacked?.Invoke(hero);
        }
        
        /// <summary>
        /// Before the caster hero deals critical strike
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroCriticalStrikes(IHero hero)
        {
            EBeforeHeroCriticalStrikes?.Invoke(hero);
        }
        
        /// <summary>
        /// Before the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroIsDealtCriticalStrike(IHero hero)
        {
            EBeforeHeroIsDealtCriticalStrike?.Invoke(hero);
        }
        
        /// <summary>
        /// After the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroIsDealtCriticalStrike(IHero hero)
        {
            EAfterHeroIsDealtCriticalStrike?.Invoke(hero);
        }
        
        /// <summary>
        /// After the hero deals critical strike
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroDealsCriticalStrike(IHero hero)
        {
            EAfterHeroDealsCriticalStrike?.Invoke(hero);
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
        
        private void UnsubscribeEventBeforeHeroAttacks()
        {
            var clients = EBeforeHeroAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroAttacks -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroIsAttacked()
        {
            var clients = EBeforeHeroIsAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsAttacked -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroAttacks()
        {
            var clients = EAfterHeroAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroAttacks -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsAttacked()
        {
            var clients = EAfterHeroIsAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsAttacked -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroSkillAttacks()
        {
            var clients = EAfterHeroSkillAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroSkillAttacks -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsSkillAttacked()
        {
            var clients = EAfterHeroIsSkillAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsSkillAttacked -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroCriticalStrikes()
        {
            var clients = EBeforeHeroCriticalStrikes?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroCriticalStrikes -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroIsDealtCriticalStrike()
        {
            var clients = EBeforeHeroIsDealtCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsDealtCriticalStrike -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsDealtCriticalStrike()
        {
            var clients = EAfterHeroIsDealtCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsDealtCriticalStrike -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroDealsCriticalStrike()
        {
            var clients = EAfterHeroDealsCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroDealsCriticalStrike -= client as HeroEvent;
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
            
            UnsubscribeEventBeforeHeroAttacks();
            UnsubscribeEventBeforeHeroIsAttacked();
            
            UnsubscribeEventAfterHeroAttacks();
            UnsubscribeEventAfterHeroIsAttacked();
            
            UnsubscribeEventAfterHeroSkillAttacks();
            UnsubscribeEventAfterHeroIsSkillAttacked();

            UnsubscribeEventBeforeHeroCriticalStrikes();
            UnsubscribeEventBeforeHeroIsDealtCriticalStrike();

            UnsubscribeEventAfterHeroIsDealtCriticalStrike();
            UnsubscribeEventAfterHeroDealsCriticalStrike();
        }
    }
}
