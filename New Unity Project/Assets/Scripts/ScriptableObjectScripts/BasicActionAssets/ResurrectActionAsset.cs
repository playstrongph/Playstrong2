using System.Collections;
using DG.Tweening;
using Logic;
using ScriptableObjectScripts.GameAnimationAssets;
using ScriptableObjectScripts.StandardActionAssets;
using UnityEngine;


namespace ScriptableObjectScripts.BasicActionAssets
{
    [CreateAssetMenu(fileName = "ResurrectAction", menuName = "Assets/BasicActions/R/ResurrectAction")]
    public class ResurrectActionAsset : BasicActionAsset
    {  
        /// <summary>
        /// Total animation delay of resurrect hero
        /// </summary>
        //[SerializeField] private float playDelayInterval = 4f;
        
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
            Debug.Log("Resurrect Action Main Basic Action Phase, TargetHero: " +targetHero.HeroName +" Caster Hero: " +casterHero.HeroName);
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;

            //Heal Animation
            logicTree.AddCurrent(ResurrectVisualAction(casterHero));

            //base class method that calls execute action after checking life status and inability status
            logicTree.AddCurrent(MainAction(casterHero));

            logicTree.EndSequence();
            yield return null;
        }
        
        protected override void SetMainExecutionActionTargetHeroes(IHero casterHero, IHero targetHero,  IStandardActionAsset standardAction)
        {
            //From the perspective of the caster hero
            var actionTargetHeroes = standardAction.BasicActionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
            
            //animation target heroes list 
            ExecuteActionTargetHeroes.Clear();
            
            
            //TEST START
            for (var index = 0; index < actionTargetHeroes.Count; index++)
            {
                var conditionTargetHeroes = standardAction.BasicConditionTargets.GetActionHeroes(casterHero,targetHero,standardAction);
                
                //Use index 0 if basic condition targets does not follow a multiple basic action targets scenario
                var conditionIndex = conditionTargetHeroes.Count < actionTargetHeroes.Count ? 0 : index;
                
                //This is effectively the actual "target hero" 
                var actionTargetHero = actionTargetHeroes[index];

                //Product of all 'And' and 'Or' basic condition logic
                if (FinalConditionValue(conditionTargetHeroes[conditionIndex],standardAction) > 0)
                {
                    //actionTargetHero.HeroLogic.HeroLifeStatus.AddToHeroList(ExecuteActionTargetHeroes,actionTargetHero);
                    
                    //Add action target hero
                    ExecuteActionTargetHeroes.Add(actionTargetHero);

                }
            }
        }
        
        
        /// <summary>
        /// Have to override dead hero checking
        /// </summary>
        /// <param name="casterHero"></param>
        /// <returns></returns>
        protected override IEnumerator MainAction(IHero casterHero)
        {
            //Debug.Log("Resurrect Main Action" +" ExecutionTargetHeroes Count: " +ExecuteActionTargetHeroes.Count);
            
            var logicTree = casterHero.CoroutineTrees.MainLogicTree;
          

            foreach (var hero in ExecuteActionTargetHeroes)
            {
                logicTree.AddCurrent(ExecuteAction(casterHero,hero));
            }

            logicTree.EndSequence();
            yield return null;
        }

        /// <summary>
        /// Resurrect hero logic
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
            
            //Debug.Log("Resurrect hero: " +hero.HeroName);
            
            var logicTree = hero.CoroutineTrees.MainLogicTree;

            //Set hero to alive status
            hero.HeroLogic.SetHeroLifeStatus.HeroAlive();
            
            //TODO: TransferToAliveHeroesList
            logicTree.AddCurrent(TransferToAliveHeroList(hero));
            
            //TODO: Destroy Resurrect StatusEffects
            logicTree.AddCurrent(RemoveStatusEffects(hero));

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
            var turnController = targetHero.Player.BattleSceneManager.TurnController;
            var startNextHeroDelay = 5f;

            //Introduce a visual delay before Hero Timers and hero turn starts
            turnController.StartNextHeroTurn.NextTurnVisualDelay = startNextHeroDelay;

            foreach (var hero in ExecuteActionTargetHeroes)
            {
                visualTree.AddCurrent(ResurrectAnimation(hero));
            }

            logicTree.EndSequence();
            yield return null;
        }

        private IEnumerator ResurrectAnimation(IHero targetHero)
        {
            var visualTree = targetHero.CoroutineTrees.MainVisualTree;
            var sequence = DOTween.Sequence();
            var aliveHeroesParent = targetHero.Player.AliveHeroes.ThisGameObject;
            var heroObject = targetHero.ThisGameObject;
            var heroDiesInterval = 3f;  //Note: 2 sec hero dies interval plus 1 second buffer

            sequence
                .AppendInterval(heroDiesInterval)
                .AppendCallback(() => heroObject.transform.SetParent(aliveHeroesParent.transform))
                
                //TODO: Replace with Resurrect Animation Asset
                .AppendCallback(() => HealAnimationAsset.PlayAnimation(targetHero));

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
