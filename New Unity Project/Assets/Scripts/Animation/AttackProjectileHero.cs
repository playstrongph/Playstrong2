using UnityEngine;
using UnityEngine.UI;

namespace Animation
{
    public class AttackProjectileHero : AttackProjectile
    {
        /// <summary>
        /// Set in the inspector
        /// </summary>
        [SerializeField] private Canvas canvas;

        /// <summary>
        /// Set in the inspector
        /// </summary>
        [SerializeField] private CanvasGroup canvasGroup;
        
        /// <summary>
        /// Set in the inspector
        /// </summary>
        [SerializeField] private Image image = null;

        /// <summary>
        /// Sets the attack projectile graphic
        /// </summary>
        /// <param name="sprite"></param>
        public override void SetProjectileGraphic(Sprite sprite)
        {
            image.sprite = sprite;
        }
        
        




    }
}
