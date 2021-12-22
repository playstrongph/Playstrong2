using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

namespace Logic
{
    public class HeroFrameAndGlow : MonoBehaviour, IHeroFrameAndGlow
    {
        #region VARIABLES AND PROPERTIES

        [SerializeField] private Image actionGlow;
        private Image ActionGlow { get => actionGlow; set => actionGlow = value; }
        
        [SerializeField] private Image enemyGlow;
        private Image EnemyGlow { get => enemyGlow; set => enemyGlow = value; }
        
        [SerializeField] private Image allyGlow;
        private Image AllyGlow { get => allyGlow; set => allyGlow = value; }
        
        [SerializeField] private Image frameImage;
        private Image FrameImage { get => frameImage; set => frameImage = value; }
        
        [Header("2D LIGHTS")]
        
        [SerializeField] private Light2D actionLight;
        private Light2D ActionLight { get => actionLight; set => actionLight = value; }
        
        [SerializeField] private Light2D enemyLight;
        private Light2D EnemyLight { get => enemyLight; set => enemyLight = value; }
        
        [SerializeField] private Light2D allyLight;
        private Light2D AllyLight { get => allyLight; set => allyLight = value; }
        
        /// <summary>
        /// Returns the game object component of normal frame
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;
        
        #endregion

        #region EXECUTION
        
        /// <summary>
        /// Enables green border and light visual
        /// </summary>
        public void EnableActionLightAndGlow()
        {
            ActionGlow.enabled = true;
            ActionLight.enabled = true;
        }
        
        /// <summary>
        /// Disables green border and light visual
        /// </summary>
        public void DisableActionLightAndGlow()
        {
            ActionGlow.enabled = false;
            ActionLight.enabled = false;
        }
        
        /// <summary>
        /// Enable red border and light visual
        /// </summary>
        public void EnableEnemyLightAndGlow()
        {
            EnemyGlow.enabled = true;
            EnemyLight.enabled = true;
        }
        
        /// <summary>
        /// Disable red border and light visual
        /// </summary>
        public void DisableEnemyLightAndGlow()
        {
            EnemyGlow.enabled = false;
            EnemyLight.enabled = false;
        }
        
        /// <summary>
        /// Enable yellow border and light visual
        /// </summary>
        public void EnableAllyLightAndGlow()
        {
            AllyGlow.enabled = true;
            AllyLight.enabled = true;
        }
        
        /// <summary>
        /// Disable yellow border and light visual
        /// </summary>
        public void DisableAllyLightAndGlow()
        {
            AllyGlow.enabled = false;
            AllyLight.enabled = false;
        }
        
        /// <summary>
        /// Turn-on frame Image
        /// Used for Taunt frame only
        /// </summary>
        public void EnableFrameImage()
        {
            FrameImage.enabled = true;
        }
        /// <summary>
        /// Turn-off frame Image
        /// Used for Taunt frame only
        /// </summary>
        public void DisableFrameImage()
        {
            FrameImage.enabled = false;
        }





        #endregion
        
        
    }
}