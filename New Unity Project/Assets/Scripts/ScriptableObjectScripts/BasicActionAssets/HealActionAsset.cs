using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
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
        [Header("HEALING FACTORS")]
        [SerializeField] private int flatValue = 0;
        
        
        /// <summary>
        /// Increase value by percentage health factor
        /// </summary>
        [Header("Health Factors")]
        [SerializeField] private int percentCasterBaseHealthValue = 0;
        
        /// <summary>
        /// Increase value by percentage health factor
        /// </summary>
        [SerializeField] private int percentTargetBaseHealthValue = 0;
        
        [Header("Damage Factors")]
        [SerializeField] private int percentCasterDamageDealt = 0;
        [SerializeField] private int percentTargetDamageTaken = 0;

        [Header("ANIMATIONS")] 

        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject healAnimationAsset;
        /// <summary>
        /// Heal animation asset
        /// </summary>
        private IGameAnimationsAsset HealAnimationAsset
        {
            get => healAnimationAsset as IGameAnimationsAsset;
            set => healAnimationAsset = value as ScriptableObject;
        }
        
        //TODO: Test
        /// <summary>
        /// Local variable for total healing amount
        /// </summary>
        [SerializeField] private int totalHealValue = 0;
        
        
        /// <summary>
        /// The specific logic-visual sequence for basic action
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //Heal Animation
            logicTree.AddCurrent(HealVisualAction(casterHero));

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
            //Healing factors calculation
            var baseHealthHeal = BaseHealthHeal(casterHero, targetHero);
            var damageDealtOrTakenHeal = DamageDealtOrTakenHeal(casterHero, targetHero);
            
            //Set total healing here
            totalHealValue = flatValue + baseHealthHeal +damageDealtOrTakenHeal;

            //New Health calculations
            var newHealth = targetHero.HeroLogic.HeroAttributes.Health + totalHealValue;
            targetHero.HeroLogic.SetHealth.StartAction(newHealth);
        }
        
        /// <summary>
        /// Total healing based on base health
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private int BaseHealthHeal(IHero casterHero,IHero targetHero)
        {
            var healValue = 0;
            
            var casterBaseHealth = casterHero.HeroLogic.HeroAttributes.BaseHealth;
            var targetBaseHealth = targetHero.HeroLogic.HeroAttributes.BaseHealth;

            var casterBaseHealthHealValue = Mathf.RoundToInt(casterBaseHealth * percentCasterBaseHealthValue / 100f);
            var targetBaseHealthHealValue = Mathf.RoundToInt(targetBaseHealth * percentTargetBaseHealthValue / 100f);

            healValue = casterBaseHealthHealValue + targetBaseHealthHealValue;
            
            return healValue;
        }
        
        /// <summary>
        /// Total healing based on damage dealt or taken
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private int DamageDealtOrTakenHeal(IHero casterHero,IHero targetHero)
        {
            var healValue = 0;
            var casterDamageDealt = casterHero.HeroLogic.DealDamage.FinalDamageDealt;
            var targetDamageTaken = targetHero.HeroLogic.TakeDamage.FinalDamageTaken;

            var casterDamageDealtHealValue = Mathf.RoundToInt(casterDamageDealt * percentCasterDamageDealt / 100f);
            var targetDamageTakenHealValue = Mathf.RoundToInt(targetDamageTaken * percentTargetDamageTaken / 100f);

            healValue = casterDamageDealtHealValue + targetDamageTakenHealValue;
            
            return healValue;
        }


        #region VISUALS REGION

        /// <summary>
        /// Healing Animation and Healing Amount Text Display
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator HealVisualAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            foreach (var hero in ExecuteActionTargetHeroes)
            {
                visualTree.AddCurrent(HealAnimation(hero));
            }
            
            if(ExecuteActionTargetHeroes.Count > 0)
                visualTree.AddCurrent(AnimationInterval(targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator HealAnimation(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;

            HealAnimationAsset.PlayAnimation(totalHealValue.ToString(),targetHero);
            
            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Attack animation delay interval
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator AnimationInterval(IHero casterHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            var sequence = DOTween.Sequence();
            
            var interval = HealAnimationAsset.AnimationDuration;

            sequence
                .AppendInterval(interval)
                //This is the animation delay interval
                .AppendCallback(() => visualTree.EndSequence());
             
            yield return null;
        }

        #endregion"
        
        
        
        
       



    }
}
