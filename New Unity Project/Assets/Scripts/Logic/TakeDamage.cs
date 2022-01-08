using System;
using System.Collections;
using UnityEngine;

namespace Logic
{
    public class TakeDamage : MonoBehaviour
    {
        private int _residualDamage;

        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }


        public IEnumerator TakeSingleAttackDamage(int targetedHero, int nonCriticalDamage, int criticalDamage)
        {
            
        }

    }
}
