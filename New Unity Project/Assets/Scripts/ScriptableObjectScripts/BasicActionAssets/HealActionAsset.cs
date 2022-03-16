using System.Collections;
using Logic;
using UnityEngine;


namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "HealAction", menuName = "Assets/BasicActions/H/HealAction")]
    public class HealActionAsset : BasicActionAsset
    {
        /// <summary>
        /// Default chance to heal.  Primarily used by skills, 100% for status effects
        /// </summary>
        [Header("Default Healing Chance")]
        [SerializeField] private int defaultChance = 0;


        /// <summary>
        /// Increase value by a fixed amount
        /// </summary>
        [Header("Healing Factors")]
        [SerializeField] private int flatValue = 0;

        /// <summary>
        /// Increase value by percentage health factor
        /// </summary>
        [SerializeField] private int percentCasterBaseHealthValue = 0;
        
        /// <summary>
        /// Increase value by percentage health factor
        /// </summary>
        [SerializeField] private int percentTargetBaseHealthValue = 0;
        
        
        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //TODO: heal animation

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Increase attack logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            var healChance = casterHero.HeroLogic.ChanceAttributes.HealChance + defaultChance;
            var healResistance = targetHero.HeroLogic.ResistanceAttributes.HealResistance;
            var netChance = healChance - healResistance;
            var randomChance = Random.Range(1f, 100f);
            
            if(randomChance <= netChance)
                HealHero(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Main heal function
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        private void HealHero(IHero casterHero, IHero targetHero)
        {
            //Healing based on percentage health
            var casterBaseHealth = casterHero.HeroLogic.HeroAttributes.BaseHealth;
            var targetBaseHealth = targetHero.HeroLogic.HeroAttributes.BaseHealth;
            var casterBaseHealthHealValue = Mathf.RoundToInt(casterBaseHealth * percentCasterBaseHealthValue / 100f);
            var targetBaseHealthHealValue = Mathf.RoundToInt(targetBaseHealth * percentTargetBaseHealthValue / 100f);

            var healAmount = flatValue + casterBaseHealthHealValue + targetBaseHealthHealValue;

            var newHealth = targetHero.HeroLogic.HeroAttributes.Health + healAmount;
            
            targetHero.HeroLogic.SetHealth.StartAction(newHealth);

        }



    }
}
