using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
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
        [SerializeField] private int defaultChance = 0;
        
        
        [Header("ANIMATIONS")]
        [SerializeField]
        [RequireInterfaceAttribute.RequireInterface(typeof(IGameAnimationsAsset))]
        private ScriptableObject addStatusEffectAnimationAsset;
        /// <summary>
        /// Floating Text animation asset
        /// </summary>
        private IGameAnimationsAsset AddStatusEffectAnimationAsset
        {
            get => addStatusEffectAnimationAsset as IGameAnimationsAsset;
            set => addStatusEffectAnimationAsset = value as ScriptableObject;
        }
        
        
        

        /// <summary>
        ///  Calls Execute action if: 1) caster and target hero are alive
        /// 2) caster has no inability effects
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <param name="standardAction"></param>
        /// <returns></returns>
        protected override IEnumerator MainBasicActionPhase(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            
          
            //TODO: Transfer this
            logicTree.AddCurrent(AddStatusEffectAnimationVisual(casterHero));
            
            logicTree.AddCurrent(MainAction(casterHero));
            
            //TODO: AddStatusEffectAnimationInterval here

            logicTree.EndSequence();
            yield return null;
        }
        
        //TODO: Transfer this to CreateStatusEffectVisual inside statuseffect instance type
        private IEnumerator AddStatusEffectAnimationVisual(IHero casterHero)
        {
            var logicTre = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;

            foreach (var hero in MainExecutionActionHeroes)
            {
                visualTree.AddCurrent(AddStatusEffectVisual(hero));
            }
            
            //Animation Interval 
            visualTree.AddCurrent(AddStatusEffectAnimationInterval(casterHero));
            
            logicTre.EndSequence();
            yield return null;
        }
        
        private IEnumerator AddStatusEffectVisual(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            //set status effect text name
            var statusEffectText = StatusEffectAsset.StatusEffectName;

            AddStatusEffectAnimationAsset.PlayAnimation(statusEffectText,targetHero);
            
            visualTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator AddStatusEffectAnimationInterval(IHero casterHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            var sequence = DOTween.Sequence();
            var attackAnimationInterval = AddStatusEffectAnimationAsset.AnimationDuration;

             
            sequence
                .AppendInterval(attackAnimationInterval)
                //This is the animation delay interval
                .AppendCallback(() => visualTree.EndSequence());
             
            yield return null;
        }


        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            AddStatusEffect(targetHero,casterHero);

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
            //Add status effect based on status effect asset type, chance, and resistances
            StatusEffectAsset.StatusEffectType.AddTypeOfStatusEffect(StatusEffectAsset,casterHero,targetHero,defaultChance,statusEffectCounters);

            //TODO: Delete this after cleanup
            /*//Caster's total add buff chance. 
            var buffChance = casterHero.HeroLogic.ChanceAttributes.BuffChance + defaultChance;
            
            //Target's buff resistance
            var buffResistance = targetHero.HeroLogic.ResistanceAttributes.BuffResistance;
            
            //Effective add buff chance
            var netBuffChance = buffChance - buffResistance;
            
            //Random chance, 1 to 100.
            var randomChance = Random.Range(1, 101);
            
            //Example - addBuffChance is 75% and random chance is 50.
            //TODO: Need to carve out animations here: StatusEffect action animations, update status effect counters, 
            //TODO: show status effect symbol
            if(randomChance <= netBuffChance)
                StatusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,StatusEffectAsset,statusEffectCounters);*/
        }

      






    }
}
