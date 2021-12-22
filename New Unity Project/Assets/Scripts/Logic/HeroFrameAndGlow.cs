﻿using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

namespace Logic
{
    public class HeroFrameAndGlow : MonoBehaviour, IHeroFrameAndGlow
    {
        #region VARIABLES AND PROPERTIES

        [SerializeField] private Image actionGlow;
        public Image ActionGlow { get => actionGlow; set => actionGlow = value; }
        
        [SerializeField] private Image enemyGlow;
        public Image EnemyGlow { get => enemyGlow; set => enemyGlow = value; }
        
        [SerializeField] private Image allyGlow;
        public Image AllyGlow { get => allyGlow; set => allyGlow = value; }
        
        [SerializeField] private Image frameImage;
        public Image FrameImage { get => frameImage; set => frameImage = value; }
        
        [Header("2D LIGHTS")]
        
        [SerializeField] private Light2D actionLight;
        public Light2D ActionLight { get => actionLight; set => actionLight = value; }
        
        [SerializeField] private Light2D enemyLight;
        public Light2D EnemyLight { get => enemyLight; set => enemyLight = value; }
        
        [SerializeField] private Light2D allyLight;
        public Light2D AllyLight { get => allyLight; set => allyLight = value; }
        
        /// <summary>
        /// Returns the game object component of normal frame
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
        #endregion

        #region EXECUTION
        
        /// <summary>
        /// Turns on green border and light visual
        /// </summary>
        public void EnableActionGlow()
        {
          
        }
        
        
        
        

        #endregion
        
        
    }
}