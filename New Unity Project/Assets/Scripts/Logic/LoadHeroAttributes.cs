using System;
using UnityEngine;

namespace Logic
{
    public class LoadHeroAttributes : MonoBehaviour
    {
        /// <summary>
        /// Hero logic reference
        /// </summary>
        private IHeroLogic _heroLogic;
        
        
        
        

        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }
    }
}
