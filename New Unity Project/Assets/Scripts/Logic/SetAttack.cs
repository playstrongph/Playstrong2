﻿using UnityEngine;

namespace Logic
{
    /// <summary>
    /// Sets the hero's attack value and visual text
    /// </summary>
    public class SetAttack : MonoBehaviour, ISetAttack
    {
        private IHeroLogic _heroLogic;
        
        private void Awake()
        {
            _heroLogic = GetComponent<IHeroLogic>();
        }

        public void StartAction(int value)
        {
            _heroLogic.HeroAttributes.Attack = value;
        }

    }
}