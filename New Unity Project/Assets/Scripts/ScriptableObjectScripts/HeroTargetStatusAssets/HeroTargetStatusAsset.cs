using System.Collections;
using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.HeroTargetStatusAssets
{
    public abstract class HeroTargetStatusAsset : ScriptableObject
    {
        public virtual IEnumerator StatusAction(IHero hero, List<IHero> enemyTauntHeroes, List<IHero> enemyStealthHeroes)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Normal Target
            //Stealth Target
            //Taunt Target
            
            logicTree.EndSequence();
            yield return null;
        }
    }
}
