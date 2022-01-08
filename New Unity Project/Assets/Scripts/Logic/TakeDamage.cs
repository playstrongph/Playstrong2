using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class TakeDamage : MonoBehaviour
    {
        private int _residualDamage;

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        public IEnumerator TakeSingleAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeMultiAttackDamage(int nonCriticalDamage, int criticalDamage)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeNonAttackSkillDamage(int nonAttackSkillDamage, int penetrateArmorChance)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }
        
        public IEnumerator TakeNonSkillDamage(int nonSkillDamage, int penetrateArmorChance)
        {
            var targetedHero = _heroLogic.Hero;
            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
            
            
            logicTree.EndSequence();
            yield return null;

        }

    }
}
