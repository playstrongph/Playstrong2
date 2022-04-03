using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;


namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "DealNonSkillDamageAction", menuName = "Assets/BasicActions/D/DealNonSkillDamageAction")]
    public class DealNonSkillDamageActionAsset : BasicActionAsset
    {
        [Header("Damage Factors")] 
        
        [SerializeField] private int flatDamage = 0;
        [SerializeField] private int percentPenetrateArmor = 0;
        
        
        [Header("Base Health Factors")]
        [SerializeField] private int percentTargetBaseHealth = 0;
        [SerializeField] private int percentCasterBaseHealth = 0;

        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Execute Action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            DealNonSkillDamage(casterHero,targetHero);
            
            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Non Skill Damage function 
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        private void DealNonSkillDamage(IHero casterHero, IHero targetHero)
        {
            var nonSkillDamage = ComputeTotalDamage(casterHero, targetHero);
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //TODO: potential for cleanup
            var penetrateArmorChance = 0;

            logicTree.AddCurrent(casterHero.HeroLogic.DealDamage.DealNonSkillDamage(casterHero, targetHero, nonSkillDamage, penetrateArmorChance,
                percentPenetrateArmor));
            
        }

        private int ComputeTotalDamage(IHero casterHero,IHero targetHero)
        {
            var casterBaseHealth = casterHero.HeroLogic.HeroAttributes.BaseHealth;
            var targetBaseHealth = targetHero.HeroLogic.HeroAttributes.BaseHealth;

            var casterBaseHealthDamage = Mathf.RoundToInt(casterBaseHealth * percentCasterBaseHealth / 100f);
            var targetBaseHealthDamage = Mathf.RoundToInt(targetBaseHealth * percentTargetBaseHealth / 100f);
            
            //compute total damage
            var damage = flatDamage + casterBaseHealthDamage+targetBaseHealthDamage;

            return damage;
        }


    }
}
