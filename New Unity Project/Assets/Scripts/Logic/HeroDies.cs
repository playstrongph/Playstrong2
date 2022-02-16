using System;
using System.Collections;
using ScriptableObjectScripts.HeroLifeStatusAssets;
using UnityEngine;

namespace Logic
{
    public class HeroDies : MonoBehaviour
    {

       private IHeroLogic _heroLogic;

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
           
           //Update Dead Status Action based on current health
           logicTree.AddCurrent(UpdateHeroDeadStatus(hero));
           
           //Call hero death actions if life less than or equal to zero
           logicTree.AddCurrent(HeroDeath(hero));
           
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
               
               //TODO: Event post hero death
               logicTree.AddCurrent(EventPostHeroDeath(hero));
               
           }

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
