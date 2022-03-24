using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.AttackTargetCountTypeAssets;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "ReflectNonSkillDamageAction", menuName = "Assets/BasicActions/R/ReflectNonSkillDamageAction")]
    public class ReflectNonSkillDamageActionAsset : BasicActionAsset
    {
        #region VARIABLES

        [SerializeField] private float reflectValue = 0;

        [SerializeField] private int penetrateArmorChance = 0;


        #endregion

        #region EXECUTION

        /// <summary>
        /// Calls the basic action's specific effects
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            ReflectAttackDamage(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        

        /// <summary>
        /// Reflect attack damage logic
        /// </summary>
        /// <param name="casterHero"></param>
        ///  <param name="targetHero"></param>
        private void ReflectAttackDamage(IHero casterHero,IHero targetHero)
        {
            //Note: the casterHero is the target of the reflect damage, and the target hero is just a dummy (not required)
            var reflectDamageHeroBasis = targetHero;
            var reflectDamageRecipient = casterHero;

            var reflectDamage = Mathf.RoundToInt((reflectValue / 100f) * reflectDamageHeroBasis.HeroLogic.TakeDamage.FinalDamageTaken);
            
           //TODO: remove reflect damage hero basis as arg after Take Non Skill Damage cleanup
            reflectDamageRecipient.HeroLogic.TakeDamage.TakeNonSkillDamage(reflectDamageHeroBasis,
                reflectDamageHeroBasis, reflectDamage, penetrateArmorChance);

        }

        #endregion

        #region ANIMATION

        #endregion

        #region EVENTS
        
        /// <summary>
        /// All events before main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator CallPreBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Note: the casterHero is the target of the reflect damage, and the target hero is the source of the reflect damage
            var reflectDamageRecipient = casterHero;
            
            reflectDamageRecipient.HeroLogic.HeroEvents.EventBeforeHeroTakesNonSkillDamage(reflectDamageRecipient);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// All events after main basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator CallPostBasicActionEvents(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Note: the casterHero is the target of the reflect damage, and the target hero is the source of the reflect damage
            var reflectDamageRecipient = casterHero;
            
            reflectDamageRecipient.HeroLogic.HeroEvents.EventAfterHeroTakesNonSkillDamage(reflectDamageRecipient);

            logicTree.EndSequence();
            yield return null;
        }
        
       
        #endregion
       

    }
}
