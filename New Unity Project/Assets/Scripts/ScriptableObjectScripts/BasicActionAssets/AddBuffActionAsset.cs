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
        /// </summary>
        [SerializeField] private int defaultAddBuffChance = 0;
        
        
        public override IEnumerator ExecuteAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;

            var casterHero = targetedHero.HeroLogic.LastHeroTargets.TargetingHero;
            
            AddStatusEffect(targetedHero,casterHero);

            logicTree.EndSequence();
            yield return null;
        }
        
        public override IEnumerator MainAnimationAction(IHero targetedHero)
        {
            var logicTree = targetedHero.CoroutineTrees.MainLogicTree;
            
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
            //Caster's total add buff chance.  Default hero buff chance is 100.
            var buffChance = casterHero.HeroLogic.ChanceAttributes.BuffChance + defaultAddBuffChance;
            
            //Target's buff resistance
            var buffResistance = targetHero.HeroLogic.ResistanceAttributes.BuffResistance;
            
            //Effective add buff chance
            var addBuffChance = buffChance - buffResistance;
            
            //Random chance, 1 to 100.
            var randomChance = Random.Range(1, 101);
            
            //Example - addBuffChance is 75% and random chance is 50.
            if(randomChance <= addBuffChance)
                StatusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,StatusEffectAsset, statusEffectCounters);
        }






    }
}
