using System.Collections;
using UnityEngine;

namespace Logic
{
    public class StartNextHeroTurn : MonoBehaviour, IStartNextHeroTurn
    {
        private ITurnController _turnController;

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

            logicTree.AddCurrent(_turnController.ActiveHeroes.Count > 0
                ? _turnController.SetCurrentActiveHero.StartAction()
                : _turnController.StartHeroTimers());

            logicTree.EndSequence();
            yield return null;
        }
    
    
    }
}
