using UnityEngine;

namespace Animation
{
    public interface IAttackProjectile
    {
        /// <summary>
        /// Sets the attack projectile graphic
        /// </summary>
        /// <param name="sprite"></param>
        void SetProjectileGraphic(Sprite sprite);
    }
}