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
           
           //TODO: Update Dead Status Action
           
           //TODO: Hero Dies action
           
       }    
        
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

       private IEnumerator SetHeroDeadStatus(IHero hero)
       {
           var logicTree = hero.CoroutineTrees.MainLogicTree;
           var health = hero.HeroLogic.HeroAttributes.Health;
           
           
           logicTree.EndSequence();
           yield return null;
       }



    }
}
