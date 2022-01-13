using UnityEngine;

namespace Animation
{
    /// <summary>
    /// Base class for all attack projectiles
    /// </summary>
    public abstract class AttackProjectile : MonoBehaviour, IAttackProjectile
    {
        /// <summary>
        /// Sets the attack projectile graphic
        /// </summary>
        /// <param name="sprite"></param>
        public virtual void SetProjectileGraphic(Sprite sprite)
        {
            
        }
    }
}
