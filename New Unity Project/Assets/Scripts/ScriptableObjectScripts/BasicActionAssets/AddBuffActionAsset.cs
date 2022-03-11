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

        [SerializeField] private float instantiateDelay = 0.5f;
        
        
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
            
            //Instantiate "Loading" buffer
            logicTree.AddCurrent(InstantiateIntervalVisual(casterHero));
            
            logicTree.AddCurrent(MainAction(casterHero));
            
            //Parallel animation interval
            logicTree.AddCurrent(AddStatusEffectIntervalVisual(casterHero));

            logicTree.EndSequence();
            yield return null;
        }

      

        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            AddStatusEffect(casterHero,targetHero);

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Adds a status effect depending on the status effect instance type and buff resistance/chances
        /// </summary>
        /// <param name="targetHero"></param>
        /// <param name="casterHero"></param>
        private void AddStatusEffect(IHero casterHero, IHero targetHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;

            //net add status effect chance based on chance and resistance
            var netBuffChance =
                StatusEffectAsset.StatusEffectType.AddStatusEffectNetChance(casterHero, targetHero, defaultChance);
            
            //Random chance, 1 to 100.
            var randomChance = Random.Range(1, 101);
            
            //Example - addBuffChance is 75% and random chance is 50.
            if (randomChance <= netBuffChance)
            {
                //Play add status effect animation
                visualTree.AddCurrent(AddStatusEffectVisual(targetHero));
                
                //Add status effect
                StatusEffectAsset.StatusEffectInstanceType.AddStatusEffect(targetHero,casterHero,StatusEffectAsset,statusEffectCounters);
            }
        }
        
        /// <summary>
        /// Add status effect animation/s (floating text)
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator AddStatusEffectVisual(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            //set status effect text name
            var statusEffectText = StatusEffectAsset.StatusEffectName;

            AddStatusEffectAnimationAsset.PlayAnimation(statusEffectText,targetHero);
            
            visualTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Animation interval logic tree wrapper
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator AddStatusEffectIntervalVisual(IHero casterHero)
        {
            var logicTre = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            if(ExecuteActionTargetHeroes.Count>0)
                visualTree.AddCurrent(AddStatusEffectAnimationInterval(casterHero));
            
            logicTre.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Parallel animation interval delay
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
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
        
        
        /// <summary>
        /// Instantiate interval logic wrapper
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator InstantiateIntervalVisual(IHero casterHero)
        {
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            
            visualTree.AddCurrent(InstantiateInterval(casterHero));
            
            logicTree.EndSequence();
            yield return null;
        }



        /// <summary>
        /// Small visual delay for instantiation of game objects
        /// like a "loading' buffer
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        private IEnumerator InstantiateInterval(IHero casterHero)
        {
            var visualTree = casterHero.CoroutineTrees.MainVisualTree;
            var sequence = DOTween.Sequence();

            sequence
                .AppendInterval(instantiateDelay)
                //This is the animation delay interval
                .AppendCallback(() => visualTree.EndSequence());
             
            yield return null;
        }


      






    }
}
