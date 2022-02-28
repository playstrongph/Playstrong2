using System;
using System.Collections;
using DG.Tweening;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.HeroLifeStatusAssets;
using UnityEngine;

namespace Logic
{
    public class HeroDies : MonoBehaviour, IHeroDies
    {

       private IHeroLogic _heroLogic;

       [SerializeField] private float animationInterval = 1f;
       
       
       [Header("ANIMATIONS")]
       [SerializeField]
       [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
       private ScriptableObject deathAnimationAsset;
       /// <summary>
       /// Death animation asset
       /// </summary>
       private IGameAnimationsAsset DeathAnimationsAsset
       {
           get => deathAnimationAsset as IGameAnimationsAsset;
           set => deathAnimationAsset = value as ScriptableObject;
       }

       private void Awake()
       {
           _heroLogic = GetComponent<IHeroLogic>();
       }
        
       /// <summary>
       /// Checks if fatal damage kills hero 
       /// </summary>
       /// <param name="hero"></param>
       public void CheckFatalDamage(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;

           //If immortality or similar effects are present, shall prevent the hero from dying
           logicTree.AddCurrent(EventHeroTakesFatalDamage(hero));

           //Call hero death actions if life less than or equal to zero
           //TODO: check if this should be add sibling (TEST)
           logicTree.AddSibling(HeroDeath(hero));
           
           //Note: All three methods above should be coroutines because they depend on the result of
           //the previous one
           
       }

       /// <summary>
       /// Sets the life status to hero dead if health is less or equal to zero.  This has to be wrapped
       /// inside a coroutine because of the prior event called
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator UpdateHeroDeadStatus(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var health = hero.HeroLogic.HeroAttributes.Health;
           
           if(health<=0)
               hero.HeroLogic.SetHeroLifeStatus.HeroDead();
           
           logicTree.EndSequence();
           yield return null;
       }


       private IEnumerator HeroDeath(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var health = hero.HeroLogic.HeroAttributes.Health;

           if (health <= 0)
           {
               //hero dies event
               logicTree.AddCurrent(EventHeroDies(hero));
               
               //TODO: HeroDeathActions
               logicTree.AddCurrent(DeathActions(hero));
               
               //TODO: Event post hero death
               logicTree.AddCurrent(EventPostHeroDeath(hero));
               
           }

           logicTree.EndSequence();
           yield return null;
       }

        
       /// <summary>
       /// When hero dies actions
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator DeathActions(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           
           //hero dies animation
           logicTree.AddCurrent(HeroDiesAnimation(hero));
           
           //Transfer from alive to dead heroes list
           logicTree.AddCurrent(TransferAliveToDeadHeroesList(hero));
           
           //Sets health to base value
           logicTree.AddCurrent(ResetHealth(hero));
           
           //Resets hero energy to zero
           logicTree.AddCurrent(ResetEnergy(hero));

           //Update Dead Status Action based on current health
           logicTree.AddCurrent(UpdateHeroDeadStatus(hero));
           
           //Destroy all status effects
           logicTree.AddCurrent(DestroyAllStatusEffects(hero));

           //Remove hero from active heroes list 
           logicTree.AddCurrent(RemoveFromActiveHeroesList(hero));

           //Set the hero to "inactive"
           logicTree.AddCurrent(SetHeroInactive(hero));

           logicTree.EndSequence();
           yield return null;
       }
        
       /// <summary>
       /// Destroy all buffs, debuffs, and unique status effects
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator DestroyAllStatusEffects(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           
           var heroBuffs = hero.HeroStatusEffects.BuffEffects.StatusEffects;
           var heroDebuffs = hero.HeroStatusEffects.DebuffEffects.StatusEffects;
           var uniqueStatusEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects;

           foreach (var buff in heroBuffs)
           {
               buff.RemoveStatusEffect.StartAction(hero);
           }
           
           foreach (var debuff in heroDebuffs)
           {
               debuff.RemoveStatusEffect.StartAction(hero);
           }
           
           foreach (var uniqueStatusEffect in uniqueStatusEffects)
           {
               uniqueStatusEffect.RemoveStatusEffect.StartAction(hero);
           }
           
           logicTree.EndSequence();
           yield return null;

       }

       /// <summary>
       /// Logic wrapper for hero dies animation
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator HeroDiesAnimation(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var visualTree = hero.CoroutineTrees.MainVisualTree;

           visualTree.AddCurrent(HeroDiesAnimationVisual(hero));

           logicTree.EndSequence();
           yield return null;
       }
       
       /// <summary>
       /// Hero dies animation
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator HeroDiesAnimationVisual(IHero hero)
       {
           var visualTree = hero.CoroutineTrees.MainVisualTree;
           var deadHeroesParent = hero.Player.DeadHeroes.ThisGameObject;
           var heroObject = hero.ThisGameObject;
           var healthValue = hero.HeroLogic.HeroAttributes.Health;
           var energyValue = hero.HeroLogic.HeroAttributes.Energy;
           var s = DOTween.Sequence();
           var playDelayInterval = 1f;

           s
               .AppendInterval(playDelayInterval)
               .AppendCallback(() =>
                   DeathAnimationsAsset.PlayAnimation(hero)
               )
               .AppendInterval(animationInterval)
               .AppendCallback(() =>
                   heroObject.transform.SetParent(deadHeroesParent.transform)
               )
               .AppendCallback(() =>
                   hero.HeroVisual.SetHealthVisual.StartAction(healthValue)
               )
               .AppendCallback(() =>
                   hero.HeroVisual.SetEnergyVisual.StartAction(energyValue)
               );
           
           visualTree.EndSequence();
           yield return null;
       }
       
       

       /// <summary>
       /// Reset the health back to base health
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator ResetHealth(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var baseHealth = hero.HeroLogic.HeroAttributes.BaseHealth;
           
           hero.HeroLogic.SetHealth.StartAction(baseHealth);
           
           logicTree.EndSequence();
           yield return null;
       }
        
     

       /// <summary>
       /// Reset the energy to zero
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator ResetEnergy(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           
           hero.HeroLogic.HeroTimer.ResetHeroTimer();
           
           logicTree.EndSequence();
           yield return null;
       }

       /// <summary>
       /// If hero status is active, remove from active heroes list
       /// this should come first before changing status to inactive
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator RemoveFromActiveHeroesList(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           
           var turnController = hero.Player.BattleSceneManager.TurnController;
           
           //If the hero is active, remove it from the active heroes list
           turnController.SetActiveHeroes.RemoveHero(hero);
           
           logicTree.EndSequence();
           yield return null;
       }
        
       /// <summary>
       /// Removes the hero from the alive heroes (game objects) list
       /// and adds it to the dead heroes (game objects) list
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator TransferAliveToDeadHeroesList(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var aliveHeroesGameObjects = hero.Player.AliveHeroes.HeroesGameObjects;
           var deadHeroesGameObjects = hero.Player.DeadHeroes.HeroesGameObjects;
           var aliveHeroes = hero.Player.AliveHeroes.Heroes;
           var deadHeroes = hero.Player.DeadHeroes.Heroes;
            
           //TODO: checking may be unnecessary
           if (aliveHeroes.Contains(hero))
           {
               //remove from alive list
               aliveHeroesGameObjects.Remove(hero.ThisGameObject);
               
               //TODO: Checking may be unnecessary
               if (!deadHeroes.Contains(hero))
               {
                   //add to dead heroes game objects
                   deadHeroesGameObjects.Add(hero.ThisGameObject);    
               }
           }
           
           logicTree.EndSequence();
           yield return null;
       }
        
       /// <summary>
       /// Set the hero active status to inactive and then run the status action
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator SetHeroInactive(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;

           //set the hero's active status to "Inactive Hero"
           hero.HeroLogic.SetHeroActiveStatus.InactiveHero();
           
           //execute the status action
           hero.HeroLogic.HeroActiveStatus.StatusAction(hero);

           logicTree.EndSequence();
           yield return null;
       }


       #region EVENTS

       
       /// <summary>
       /// Calls hero takes fatal damage event if hero's health is less or
       /// equal to zero before the hero dies
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator EventHeroTakesFatalDamage(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var health = hero.HeroLogic.HeroAttributes.Health;
           
           if(health<=0)
               hero.HeroLogic.HeroEvents.EventHeroTakesFatalDamage(hero);
           
           //Note that at this point, buffs like immortality will change the health to 1 and keep 
           //the hero alive
           
           logicTree.EndSequence();
           yield return null;
       }
       
       /// <summary>
       /// Hero dies event
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator EventHeroDies(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;

           hero.HeroLogic.HeroEvents.EventHeroDies(hero);

           logicTree.EndSequence();
           yield return null;
       }
       
       /// <summary>
       /// Post hero Death event - used by resurrect, extinction, and other
       /// similar events
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator EventPostHeroDeath(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;

           hero.HeroLogic.HeroEvents.EventPostHeroDeath(hero);

           logicTree.EndSequence();
           yield return null;
       }

       
       

       #endregion



    }
}
