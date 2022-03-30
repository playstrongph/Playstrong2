using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Logic
{
    public class StartNextHeroTurn : MonoBehaviour, IStartNextHeroTurn
    {
        private ITurnController _turnController;
        
        //Programmable delay for next hero turn (or start hero timers)
        public float NextTurnVisualDelay { get; set; }

        private void Awake()
        {
            _turnController = GetComponent<ITurnController>();
        }
        
        
        /// <summary>
        /// Determines the next active hero from the active heroes list 
        /// </summary>
        /// <returns></returns>
        public IEnumerator StartAction()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;
            
            var sequence = DOTween.Sequence();

            sequence
                .AppendInterval(NextTurnVisualDelay)
                .AppendCallback(StartNextTurn)
                .AppendCallback(() => NextTurnVisualDelay = 0f);

            logicTree.EndSequence();
            yield return null;
        }

        private void StartNextTurn()
        {
            var logicTree = _turnController.CoroutineTrees.MainLogicTree;

            logicTree.AddCurrent(_turnController.ActiveHeroes.Count > 0
                ? _turnController.SetCurrentActiveHero.StartAction()
                : _turnController.StartHeroTimers());
        }


    }
}
