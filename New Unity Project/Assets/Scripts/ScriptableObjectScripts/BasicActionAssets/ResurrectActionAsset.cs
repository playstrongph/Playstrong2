using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using UnityEngine;


namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "ResurrectAction", menuName = "Assets/BasicActions/R/ResurrectAction")]
    public class ResurrectActionAsset : BasicActionAsset
    {
        

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
            logicTree.AddCurrent(ResurrectVisualAction(casterHero));

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

            logicTree.AddCurrent(ResurrectHero(targetHero));

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Resurrect hero actions
        /// </summary>
        /// <param name="hero"></param>
        /// <returns></returns>
        private IEnumerator ResurrectHero(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            //Set hero to alive status
            hero.HeroLogic.SetHeroLifeStatus.HeroAlive();
            
            //TODO: Destroy Resurrect StatusEffects
            logicTree.AddCurrent(RemoveStatusEffects(hero));

            //TODO: TransferToAliveHeroesList
            logicTree.AddCurrent(TransferToAliveHeroList(hero));

            logicTree.EndSequence();
            yield return null;
        }
        
        private IEnumerator RemoveStatusEffects(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
           
            var heroBuffs = hero.HeroStatusEffects.BuffEffects.StatusEffects;
            var heroDebuffs = hero.HeroStatusEffects.DebuffEffects.StatusEffects;
            var uniqueStatusEffects = hero.HeroStatusEffects.UniqueStatusEffects.StatusEffects;

            foreach (var buff in heroBuffs)
            {
                buff.RemoveStatusEffect.StartAction(hero);
            }
           
            foreach (var debuff in heroDebuffs)
            {
                debuff.RemoveStatusEffect.StartAction(hero);
            }
           
            foreach (var uniqueStatusEffect in uniqueStatusEffects)
            {
                uniqueStatusEffect.RemoveStatusEffect.StartAction(hero);
            }
           
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator TransferToAliveHeroList(IHero hero)
        {
            var logicTree = hero.CoroutineTrees.MainLogicTree;
            
            var aliveHeroesGameObjects = hero.Player.AliveHeroes.HeroesGameObjects;
            var deadHeroesGameObjects = hero.Player.DeadHeroes.HeroesGameObjects;
            var aliveHeroes = hero.Player.AliveHeroes.Heroes;
            var deadHeroes = hero.Player.DeadHeroes.Heroes;
            
            //TODO: checking may be unnecessary
            if (deadHeroes.Contains(hero))
            {
                //remove from dead list
                deadHeroesGameObjects.Remove(hero.ThisGameObject);

                //TODO: Checking may be unnecessary
                if (!aliveHeroes.Contains(hero))
                {
                    //add to alive list
                    aliveHeroesGameObjects.Add(hero.ThisGameObject);
                }
            }
            
            logicTree.EndSequence();
            yield return null;
        }



        /// <summary>
        /// Resurrect Animation and Healing Amount Text Display
        /// </summary>
        /// <param name="targetHero"></param>
        /// <returns></returns>
        private IEnumerator ResurrectVisualAction(IHero targetHero)
        {
            var logicTree = targetHero.CoroutineTrees.MainLogicTree;
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            foreach (var hero in ExecuteActionTargetHeroes)
            {
                visualTree.AddCurrent(ResurrectAnimation(hero));
            }
            
            if(ExecuteActionTargetHeroes.Count > 0)
                visualTree.AddCurrent(AnimationInterval(targetHero));
            
            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator ResurrectAnimation(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            
            //TODO: Provision for die animation interval here using DoTween sequence
            
            HealAnimationAsset.PlayAnimation(targetHero);
            
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



    }
}
