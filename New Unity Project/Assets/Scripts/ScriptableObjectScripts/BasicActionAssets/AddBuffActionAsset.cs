using System.Collections;
using Logic;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;

namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "AddBuffAction", menuName = "Assets/BasicActions/A/AddBuffAction")]
    public class AddBuffActionAsset : BasicActionAsset
    {
        
        
        
        [SerializeField] [RequireInterfaceAttribute.RequireInterface(typeof(IStatusEffectAsset))]
        private ScriptableObject statusEffectAsset;

        private IStatusEffectAsset StatusEffectAsset
        {
            get => statusEffectAsset as IStatusEffectAsset;
            set => statusEffectAsset = value as ScriptableObject;
        }

        [SerializeField] private int statusEffectCounters = 0;
        
        /// <summary>
        /// Default add buff chance as utilized by some skills.
        /// Example 50% chance to add Attack Up
        /// </summary>
        [SerializeField] private int addBuffChance = 0;
        
        
        public override IEnumerator ExecuteAction(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            var targetedHero = casterHero.HeroLogic.LastHeroTargets.TargetedHero;

            AddStatusEffect(targetedHero,casterHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator MainAnimationAction(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
            //No animation for add buff action
            
            logicTree.EndSequence();
            yield return null;
        }
        
        
        
        /// <summary>
        /// Adds a status effect depending on the status effect instance type and buff resistance/chances
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        private void AddStatusEffect(IHero targetHero, IHero casterHero)
        {
            //Caster's total add buff chance. 
            var buffChance = casterHero.HeroLogic.ChanceAttributes.BuffChance + addBuffChance;
            
            //Target's buff resistance
            var buffResistance = targetHero.HeroLogic.ResistanceAttributes.BuffResistance;
            
            //Effective add buff chance
            var netBuffChance = buffChance - buffResistance;
            
            //Random chance, 1 to 100.
            var randomChance = Random.Range(1, 101);
            
            //Example - addBuffChance is 75% and random chance is 50.
            if(randomChance <= netBuffChance)
                StatusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,StatusEffectAsset,statusEffectCounters);

        }






    }
}
