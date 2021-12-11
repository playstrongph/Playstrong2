using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class InitializeHeroPortraits : MonoBehaviour
    {
        /// <summary>
        /// Hero reference
        /// </summary>
        private IHero _hero;

        private void Awake()
        {
            _hero = GetComponent<IHero>();
        }

        private IEnumerator StartAction()
        {
            var logicTree = _hero.CoroutineTrees.MainLogicTree;
            var portraitLocation = _hero.Player.Portraits.ThisGameObject.transform;
            var portraitPrefab = _hero.Player.BattleSceneManager.BattleSceneSettings.HeroPortrait.ThisGameObject;
            
            
            
            logicTree.EndSequence();
            yield return null;
        }


    }
}
