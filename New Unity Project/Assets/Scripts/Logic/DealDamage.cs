using System;
using UnityEngine;

namespace Logic
{
    public class DealDamage : MonoBehaviour
    {
        private IHeroLogic _heroLogic;

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
        
        
    }
}
