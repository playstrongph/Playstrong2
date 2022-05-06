using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StatusEffectAssets;
using UnityEngine;


namespace ScriptableObjectScripts.BasicActionAssets
{
    /// <summary>
    /// Destroys specific and/or random status effects
    /// </summary>
    [CreateAssetMenu(fileName = "DestroyStatusEffectsAction", menuName = "Assets/BasicActions/D/DestroyStatusEffectsAction")]
    public class DestroyStatusEffectsActionAsset : BasicActionAsset
    {

        /// <summary>
        /// Count of debuffs to be destroyed
        /// </summary>
        [SerializeField] private int randomDebuffs = 0;
        
        /// <summary>
        /// Count of buffs to be destroyed
        /// </summary>
        [SerializeField] private int randomBuffs = 0;

        [SerializeField] private List<ScriptableObject> removeStatusEffectAssets = new List<ScriptableObject>();
        
        /// <summary>
        /// Status effects not to be removed 
        /// </summary>
        private List<IStatusEffectAsset> RemoveStatusEffectAssets
        {
            get
            {
                var removalList = new List<IStatusEffectAsset>();
                foreach (var statusEffectObject in removeStatusEffectAssets)
                {
                    var statusEffect = statusEffectObject as IStatusEffectAsset;
                    removalList.Add(statusEffect);
                }

                return removalList;
            }
        }

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
        /// Increase attack logic execution
        /// </summary>
        /// <param name="casterHero"></param>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        public override IEnumerator ExecuteAction(IHero casterHero,IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;

            DestroyStatusEffects(targetHero);
            
            DestroyRandomBuffs(targetHero,randomBuffs);
            
            DestroyRandomDebuffs(targetHero,randomDebuffs);

            logicTree.EndSequence();
            yield return null;
        }
        
        /// <summary>
        /// Destroy status effects indicated in the list
        /// </summary>
        /// <param name="hero"></param>
        private void DestroyStatusEffects(IHero hero)
        {
            var allStatusEffects = new List<IStatusEffect>();

            var uniqueStatusEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects;
            var buffs = hero.HeroStatusEffects.BuffEffects.StatusEffects;
            var debuffs = hero.HeroStatusEffects.DebuffEffects.StatusEffects;
            
            allStatusEffects.AddRange(uniqueStatusEffects);
            allStatusEffects.AddRange(buffs);
            allStatusEffects.AddRange(debuffs);

            foreach (var  statusEffectAsset in RemoveStatusEffectAssets)
            {
                var statusEffectAssetName = statusEffectAsset.StatusEffectName;

                foreach (var statusEffect in allStatusEffects)
                {
                    if(statusEffect.StatusEffectName == statusEffectAssetName)
                        statusEffect.RemoveStatusEffect.StartAction(hero);
                }
            }
        }
        
        /// <summary>
        /// Destroys random buffs
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="buffCount"></param>
        private void DestroyRandomBuffs(IHero hero, int buffCount)
        {
            var allBuffs = ShuffleStatusEffectsList(hero.HeroStatusEffects.BuffEffects.StatusEffects);
            
            var index = Mathf.Min(allBuffs.Count, buffCount);

            for (int i = index; i > 0; i--)
            {
                allBuffs[i].RemoveStatusEffect.StartAction(hero);
            }
        }
        
        /// <summary>
        /// Destroy random debuffs
        /// </summary>
        /// <param name="hero"></param>
        /// <param name="debuffCount"></param>
        private void DestroyRandomDebuffs(IHero hero, int debuffCount)
        {
            var allDebuffs = ShuffleStatusEffectsList(hero.HeroStatusEffects.DebuffEffects.StatusEffects);
            var index = Mathf.Min(allDebuffs.Count, debuffCount);

            for (int i = index; i > 0; i--)
            {
                allDebuffs[i].RemoveStatusEffect.StartAction(hero);
            }
        }





    }
}
