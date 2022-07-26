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
        
        /// <summary>
        /// Hero event signature where both caster and target heroes are required
        /// </summary>
        public delegate void HeroesEvent(IHero casterHero, IHero targetHero);

        #region EVENT DELEGATES

        public event HeroesEvent EBeforeHeroSkillAttacks;
        public event HeroesEvent EBeforeHeroIsSkillAttacked;
        public event HeroesEvent EBeforeHeroAttacks;
        public event HeroesEvent EBeforeHeroIsAttacked;
        public event HeroesEvent EAfterHeroAttacks;
        public event HeroesEvent EAfterHeroIsAttacked;
        public event HeroesEvent EAfterHeroSkillAttacks;
        public event HeroesEvent EAfterHeroIsSkillAttacked;
        public event HeroesEvent EBeforeHeroCriticalStrikes;
        public event HeroesEvent EBeforeHeroIsDealtCriticalStrike;
        public event HeroesEvent EAfterHeroIsDealtCriticalStrike;
        public event HeroesEvent EAfterHeroDealsCriticalStrike;
        public event HeroesEvent EBeforeHeroCounterAttacks;
        public event HeroesEvent EBeforeHeroIsCounterAttacked;
        public event HeroesEvent EAfterHeroCounterAttacks;
        public event HeroesEvent EAfterHeroIsCounterAttacked;
        public event HeroesEvent EBeforeHeroDealsSkillDamage;
        public event HeroesEvent EBeforeHeroTakesSkillDamage;
        public event HeroesEvent EAfterHeroDealsSkillDamage;
        public event HeroesEvent EAfterHeroTakesSkillDamage;
        
        
        //Single args
        public event HeroEvent EBeforeHeroTakesNonSkillDamage;
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
        
        //TEST NEW
        public event HeroEvent EAfterHeroChangesHealth;
     
        
        


        #endregion

        #region EVENT CALLS
        
        /// <summary>
        /// Before caster hero skill attacks 
        /// </summary>
        /// <param name="casterHero"></param>
        ///  /// <param name="targetHero"></param>
        public void EventBeforeHeroSkillAttacks(IHero casterHero, IHero targetHero)
        {
            EBeforeHeroSkillAttacks?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before targeted hero is attacked 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param> 
        public void EventEBeforeHeroIsSkillAttacked(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroIsSkillAttacked?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before the caster hero attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroAttacks(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroAttacks?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before the targeted hero is attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroIsAttacked(IHero casterHero, IHero targetHero)
        {
            EBeforeHeroIsAttacked?.Invoke(casterHero, targetHero);
        }
        
        /// <summary>
        /// After the caster hero attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroAttacks(IHero casterHero,IHero targetHero)
        {
            EAfterHeroAttacks?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After the targeted hero
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroIsAttacked(IHero casterHero,IHero targetHero)
        {
            EAfterHeroIsAttacked?.Invoke(casterHero,targetHero);

        }
        
        /// <summary>
        /// After the caster hero skill attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroSkillAttacks(IHero casterHero,IHero targetHero)
        {
            EAfterHeroSkillAttacks?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After the targeted hero is skill attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroIsSkillAttacked(IHero casterHero,IHero targetHero)
        {
            EAfterHeroIsSkillAttacked?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before the caster hero deals critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroCriticalStrikes(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroCriticalStrikes?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroIsDealtCriticalStrike(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroIsDealtCriticalStrike?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After the targeted hero is dealt critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroIsDealtCriticalStrike(IHero casterHero,IHero targetHero)
        {
            EAfterHeroIsDealtCriticalStrike?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After the hero deals critical strike
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroDealsCriticalStrike(IHero casterHero,IHero targetHero)
        {
            EAfterHeroDealsCriticalStrike?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before the hero counter attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroCounterAttacks(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroCounterAttacks?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before the hero is counter attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroIsCounterAttacked(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroIsCounterAttacked?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After the hero counter attacks
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroCounterAttacks(IHero casterHero,IHero targetHero)
        {
            EAfterHeroCounterAttacks?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After the hero is counter attacked
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroIsCounterAttacked(IHero casterHero,IHero targetHero)
        {
            EAfterHeroIsCounterAttacked?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before hero deals attack skill damage 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroDealsSkillDamage(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroDealsSkillDamage?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// Before hero takes skill damage 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventBeforeHeroTakesSkillDamage(IHero casterHero,IHero targetHero)
        {
            EBeforeHeroTakesSkillDamage?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After hero deals skill damage
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        public void EventAfterHeroDealsSkillDamage(IHero casterHero,IHero targetHero)
        {
            EAfterHeroDealsSkillDamage?.Invoke(casterHero,targetHero);
        }
        
        /// <summary>
        /// After hero takes skill damage
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        public void EventAfterHeroTakesSkillDamage(IHero casterHero,IHero targetHero)
        {
            EAfterHeroTakesSkillDamage?.Invoke(casterHero,targetHero);
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
        
        /// <summary>
        /// After hero changes health - damage, heal, set health, etc.
        /// </summary>
        /// <param name="hero"></param>
        public void EventAfterHeroChangesHealth(IHero hero)
        {
            EAfterHeroChangesHealth?.Invoke(hero);
            
            //Debug.Log("Event Hero Changes Health: " +hero.HeroName);
        }




        #endregion


        #region UNSUBSCRIBE EVENTS

        private void UnsubscribeEventBeforeHeroSkillAttacks()
        {
            var clients = EBeforeHeroSkillAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroSkillAttacks -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventEBeforeHeroIsSkillAttacked()
        {
            var clients = EBeforeHeroIsSkillAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsSkillAttacked -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroAttacks()
        {
            var clients = EBeforeHeroAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroAttacks -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroIsAttacked()
        {
            var clients = EBeforeHeroIsAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsAttacked -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroAttacks()
        {
            var clients = EAfterHeroAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroAttacks -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsAttacked()
        {
            var clients = EAfterHeroIsAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsAttacked -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroSkillAttacks()
        {
            var clients = EAfterHeroSkillAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroSkillAttacks -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsSkillAttacked()
        {
            var clients = EAfterHeroIsSkillAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsSkillAttacked -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroCriticalStrikes()
        {
            var clients = EBeforeHeroCriticalStrikes?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroCriticalStrikes -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroIsDealtCriticalStrike()
        {
            var clients = EBeforeHeroIsDealtCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsDealtCriticalStrike -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsDealtCriticalStrike()
        {
            var clients = EAfterHeroIsDealtCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsDealtCriticalStrike -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroDealsCriticalStrike()
        {
            var clients = EAfterHeroDealsCriticalStrike?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroDealsCriticalStrike -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroCounterAttacks()
        {
            var clients = EBeforeHeroCounterAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroCounterAttacks -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroIsCounterAttacked()
        {
            var clients = EBeforeHeroIsCounterAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroIsCounterAttacked -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroCounterAttacks()
        {
            var clients = EAfterHeroCounterAttacks?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroCounterAttacks -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroIsCounterAttacked()
        {
            var clients = EAfterHeroIsCounterAttacked?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroIsCounterAttacked -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroDealsSkillDamage()
        {
            var clients = EBeforeHeroDealsSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroDealsSkillDamage -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventBeforeHeroTakesSkillDamage()
        {
            var clients = EBeforeHeroTakesSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EBeforeHeroTakesSkillDamage -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroDealsSkillDamage()
        {
            var clients = EAfterHeroDealsSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroDealsSkillDamage -= client as HeroesEvent;
        }
        
        private void UnsubscribeEventAfterHeroTakesSkillDamage()
        {
            var clients = EAfterHeroTakesSkillDamage?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroTakesSkillDamage -= client as HeroesEvent;
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
        
        private void UnsubscribeEventAfterHeroChangesHealth()
        {
            var clients = EAfterHeroChangesHealth?.GetInvocationList();
            if (clients != null)
                foreach (var client in clients)
                    EAfterHeroChangesHealth -= client as HeroEvent;
        }

        #endregion

        private IHeroLogic heroLogic;
        
        private void Awake()
        {
            heroLogic = GetComponent<IHeroLogic>();
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
            UnsubscribeEventBeforeHeroCounterAttacks();
            UnsubscribeEventBeforeHeroIsCounterAttacked();
            UnsubscribeEventAfterHeroCounterAttacks();
            UnsubscribeEventAfterHeroIsCounterAttacked();
            UnsubscribeEventBeforeHeroDealsSkillDamage();
            UnsubscribeEventBeforeHeroTakesSkillDamage();
            UnsubscribeEventAfterHeroDealsSkillDamage();
            UnsubscribeEventAfterHeroTakesSkillDamage();
            UnsubscribeEventBeforeHeroTakesNonSkillDamage();
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

            UnsubscribeEventAfterHeroChangesHealth();
        }
        
    }
}
