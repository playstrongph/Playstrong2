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
        public event HeroEvent EBeforeHeroDealsSkillDamage;
        public event HeroEvent EBeforeHeroTakesSkillDamage;
        public event HeroEvent EAfterHeroDealsSkillDamage;
        public event HeroEvent EAfterHeroTakesSkillDamage;
        public event HeroEvent EBeforeDealingNonSkillDamage;
        public event HeroEvent EBeforeHeroTakesNonSkillDamage;
        public event HeroEvent EAfterDealingNonSkillDamage;
        public event HeroEvent EAfterHeroTakesNonSkillDamage;
        public event HeroEvent EBeforeHeroDealsSingleTargetAttack;
        public event HeroEvent EBeforeHeroTakesSingleTargetAttack;
        public event HeroEvent EAfterHeroDealsSingleTargetAttack;
        public event HeroEvent EAfterHeroTakesSingleTargetAttack;
        public event HeroEvent EBeforeHeroTakesMultiTargetAttack;
        public event HeroEvent EBeforeHeroDealsMultiTargetAttack;
        public event HeroEvent EAfterHeroDealsMultiTargetAttack;
        public event HeroEvent EAfterHeroTakesMultiTargetAttack; 
        public event HeroEvent EAfterHeroEndTurn;
        public event HeroEvent EBeforeHeroStartTurn;
        public event HeroEvent EHeroTakesFatalDamage;
        public event HeroEvent EHeroDies;
        public event HeroEvent EPostHeroDeath;
     
        
        


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
        
        /// <summary>
        /// Before hero deals skill damage 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroDealsSkillDamage(IHero hero)
        {
            EBeforeHeroDealsSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero takes skill damage 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroTakesSkillDamage(IHero hero)
        {
            EBeforeHeroTakesSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero deals skill damage
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroDealsSkillDamage(IHero hero)
        {
            EAfterHeroDealsSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero takes skill damage
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroTakesSkillDamage(IHero hero)
        {
            EAfterHeroTakesSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// Before a non-hero source deals damage (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeDealingNonSkillDamage(IHero hero)
        {
            EBeforeDealingNonSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero takes damage from a non-hero source (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroTakesNonSkillDamage(IHero hero)
        {
            EBeforeHeroTakesNonSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// After a non-hero source deals damage (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterDealingNonSkillDamage(IHero hero)
        {
            EAfterDealingNonSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// After a hero takes damage from a non-hero source (e.g. weapons, status effects)
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroTakesNonSkillDamage(IHero hero)
        {
            EAfterHeroTakesNonSkillDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero deals single target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroDealsSingleTargetAttack(IHero hero)
        {
            EBeforeHeroDealsSingleTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero takes single target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroTakesSingleTargetAttack(IHero hero)
        {
            EBeforeHeroTakesSingleTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero deals single target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroDealsSingleTargetAttack(IHero hero)
        {
            EAfterHeroDealsSingleTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero takes single target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroTakesSingleTargetAttack(IHero hero)
        {
            EAfterHeroTakesSingleTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero takes multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroTakesMultiTargetAttack(IHero hero)
        {
            EBeforeHeroTakesMultiTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero deals multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroDealsMultiTargetAttack(IHero hero)
        {
            EBeforeHeroDealsMultiTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero deals multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroDealsMultiTargetAttack(IHero hero)
        {
            EAfterHeroDealsMultiTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero takes multi target attack 
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroTakesMultiTargetAttack(IHero hero)
        {
            EAfterHeroTakesMultiTargetAttack?.Invoke(hero);
        }
        
        /// <summary>
        /// After hero end turn (different from hero end turn event)
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroEndTurn(IHero hero)
        {
            EAfterHeroEndTurn?.Invoke(hero);
        }
        
        /// <summary>
        /// Before hero start turn (different from hero end turn event)
        /// </summary>
        /// <param name="hero"></param>
        public void EventBeforeHeroStartTurn(IHero hero)
        {
            EBeforeHeroStartTurn?.Invoke(hero);
        }
        
        /// <summary>
        /// When hero takes fatal damage, before dying
        /// </summary>
        /// <param name="hero"></param>
        public void EventHeroTakesFatalDamage(IHero hero)
        {
            EHeroTakesFatalDamage?.Invoke(hero);
        }
        
        /// <summary>
        /// Hero dies event
        /// </summary>
        /// <param name="hero"></param>
        public void EventHeroDies(IHero hero)
        {
            EHeroDies?.Invoke(hero);
        }
        
        /// <summary>
        /// Post hero death event used by resurrection and extinction
        /// </summary>
        /// <param name="hero"></param>
        public void EventPostHeroDeath(IHero hero)
        {
            EPostHeroDeath?.Invoke(hero);
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
        
        private void UnsubscribeEventBeforeHeroDealsSkillDamage()
        {
            var clients = EBeforeHeroDealsSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroDealsSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroTakesSkillDamage()
        {
            var clients = EBeforeHeroTakesSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroTakesSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroDealsSkillDamage()
        {
            var clients = EAfterHeroDealsSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroDealsSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroTakesSkillDamage()
        {
            var clients = EAfterHeroTakesSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroTakesSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeDealingNonSkillDamage()
        {
            var clients = EBeforeDealingNonSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeDealingNonSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroTakesNonSkillDamage()
        {
            var clients = EBeforeHeroTakesNonSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroTakesNonSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroTakesNonSkillDamage()
        {
            var clients = EAfterHeroTakesNonSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroTakesNonSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterDealingNonSkillDamage()
        {
            var clients = EAfterDealingNonSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterDealingNonSkillDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroDealsSingleTargetAttack()
        {
            var clients = EBeforeHeroDealsSingleTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroDealsSingleTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroTakesSingleTargetAttack()
        {
            var clients = EBeforeHeroTakesSingleTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroTakesSingleTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroDealsSingleTargetAttack()
        {
            var clients = EAfterHeroDealsSingleTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroDealsSingleTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroTakesSingleTargetAttack()
        {
            var clients = EAfterHeroTakesSingleTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroTakesSingleTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroDealsMultiTargetAttack()
        {
            var clients = EBeforeHeroDealsMultiTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroDealsMultiTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroDealsMultiTargetAttack()
        {
            var clients = EAfterHeroDealsMultiTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroDealsMultiTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroTakesMultiTargetAttack()
        {
            var clients = EBeforeHeroTakesMultiTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroTakesMultiTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroTakesMultiTargetAttack()
        {
            var clients = EAfterHeroTakesMultiTargetAttack?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroTakesMultiTargetAttack -= client as HeroEvent;
        }
        
        private void UnsubscribeEventAfterHeroEndTurn()
        {
            var clients = EAfterHeroEndTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroEndTurn -= client as HeroEvent;
        }
        
        private void UnsubscribeEventBeforeHeroStartTurn()
        {
            var clients = EBeforeHeroStartTurn?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroStartTurn -= client as HeroEvent;
        }
        
        private void UnsubscribeEventHeroTakesFatalDamage()
        {
            var clients = EHeroTakesFatalDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EHeroTakesFatalDamage -= client as HeroEvent;
        }
        
        private void UnsubscribeEventHeroDies()
        {
            var clients = EHeroDies?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EHeroDies -= client as HeroEvent;
        }
        
        private void UnsubscribeEventPostHeroDeath()
        {
            var clients = EPostHeroDeath?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EPostHeroDeath -= client as HeroEvent;
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
            UnsubscribeEventBeforeHeroDealsSkillDamage();
            UnsubscribeEventBeforeHeroTakesSkillDamage();
            UnsubscribeEventAfterHeroDealsSkillDamage();
            UnsubscribeEventAfterHeroTakesSkillDamage();
            UnsubscribeEventBeforeDealingNonSkillDamage();
            UnsubscribeEventBeforeHeroTakesNonSkillDamage();
            UnsubscribeEventAfterDealingNonSkillDamage();
            UnsubscribeEventAfterHeroTakesNonSkillDamage();
            UnsubscribeEventBeforeHeroDealsSingleTargetAttack();
            UnsubscribeEventBeforeHeroTakesSingleTargetAttack();
            UnsubscribeEventAfterHeroDealsSingleTargetAttack();
            UnsubscribeEventAfterHeroTakesSingleTargetAttack();
            UnsubscribeEventBeforeHeroDealsMultiTargetAttack();
            UnsubscribeEventAfterHeroDealsMultiTargetAttack();
            UnsubscribeEventBeforeHeroTakesMultiTargetAttack();
            UnsubscribeEventAfterHeroTakesMultiTargetAttack();
            UnsubscribeEventAfterHeroEndTurn();
            UnsubscribeEventBeforeHeroStartTurn();
            UnsubscribeEventHeroTakesFatalDamage();
            UnsubscribeEventHeroDies();
            UnsubscribeEventPostHeroDeath();
        }
        
    }
}
