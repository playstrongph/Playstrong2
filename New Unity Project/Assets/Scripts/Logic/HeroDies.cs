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

           //Set "HeroDead" status then cal hero death actions and events
           logicTree.AddCurrent(HeroDeath(hero));
           
           //Note: All three methods above should be coroutines because they depend on the result of
           //the previous one
           
       }
       private IEnumerator HeroDeath(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           
           
           var health = hero.HeroLogic.HeroAttributes.Health;

           if (health <= 0)
           {
               //Immediately set the life status to HeroDead to prevent action triggers
               hero.HeroLogic.SetHeroLifeStatus.HeroDead();
               
               //death effects should be called here
               logicTree.AddSibling(EventHeroDies(hero));
               
               //Death cleanup and hero reset actions
               logicTree.AddSibling(DeathActions(hero));
               
               //Exclusive for Resurrect type effects only
               logicTree.AddSibling(EventPostHeroDeath(hero));
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
           var visualTree = hero.CoroutineTrees.MainVisualTree;

           //Transfer from alive to dead heroes list
           logicTree.AddCurrent(TransferAliveToDeadHeroesList(hero));

           //Destroy all status effects
           logicTree.AddCurrent(RemoveStatusEffectsAtDeath(hero));

           //Remove hero from active heroes list 
           logicTree.AddCurrent(RemoveFromActiveHeroesList(hero));

           //Set the hero to "inactive"
           logicTree.AddCurrent(SetHeroInactive(hero));
           
           //Sets health to base value
           logicTree.AddCurrent(ResetHealth(hero));
           
           //Resets hero energy to zero
           logicTree.AddCurrent(ResetEnergy(hero));

           //hero dies animation 
           logicTree.AddCurrentVisual(visualTree, HeroDiesAnimation(hero));

           logicTree.EndSequence();
           yield return null;
       }
        
       /// <summary>
       /// Destroy all buffs, debuffs, and unique status effects
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator RemoveStatusEffectsAtDeath(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           
           var heroBuffs = hero.HeroStatusEffects.BuffEffects.StatusEffects;
           var heroDebuffs = hero.HeroStatusEffects.DebuffEffects.StatusEffects;
           var uniqueStatusEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects;

           foreach (var buff in heroBuffs)
           {
               buff.RemoveStatusEffect.RemoveAtDeath(hero);
           }
           
           foreach (var debuff in heroDebuffs)
           {
               debuff.RemoveStatusEffect.RemoveAtDeath(hero);
           }
           
           foreach (var uniqueStatusEffect in uniqueStatusEffects)
           {
               uniqueStatusEffect.RemoveStatusEffect.RemoveAtDeath(hero);
           }
           
           logicTree.EndSequence();
           yield return null;
       }

       /// <summary>
       /// Hero dies animation
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator HeroDiesAnimation(IHero hero)
       {
           
           
           var visualTree = hero.CoroutineTrees.MainVisualTree;
           
           var deadHeroesParent = hero.Player.DeadHeroes.ThisGameObject;
           var heroObject = hero.ThisGameObject;
           var healthValue = hero.HeroLogic.HeroAttributes.Health;
           var energyValue = hero.HeroLogic.HeroAttributes.Energy;
           var baseHealth = hero.HeroLogic.HeroAttributes.BaseHealth;
           var sequence = DOTween.Sequence();
           var playDelayInterval = 1f;

           sequence
               .AppendInterval(playDelayInterval)
               .AppendCallback(() =>
                   DeathAnimationsAsset.PlayAnimation(hero)
               )
               .AppendInterval(animationInterval)
               .AppendCallback(() =>
                   heroObject.transform.SetParent(deadHeroesParent.transform)
               )
               //Reset Health Text
               .AppendCallback(() => hero.HeroVisual.SetHealthVisual.StartAction(baseHealth))
               //Reset Energy Text
               .AppendCallback(() => hero.HeroVisual.SetEnergyVisual.StartAction(0));
           
           visualTree.EndSequence();
           yield return null;
       }
       
       /// <summary>
       /// No visual call since there is an animation with delay in between
       /// Need to immediately effect reset of health before revive is called
       /// </summary>
       /// <param name="hero"></param>
       /// <returns></returns>
       private IEnumerator ResetHealth(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
            
           var baseHealth = hero.HeroLogic.HeroAttributes.BaseHealth;
           
           //No Visuals
           hero.HeroLogic.HeroAttributes.Health = baseHealth;

           logicTree.EndSequence();
           yield return null;
       }
       
       /// <summary>
       /// No visual call since there is an animation with delay in between
       /// Need to immediately effect reset of health before revive is called
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
