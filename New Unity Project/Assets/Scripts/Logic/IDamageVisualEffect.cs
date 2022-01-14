using UnityEngine.UI;

namespace Logic
{
    public interface IDamageVisualEffect
    {
        /// <summary>
        /// Plays the damage animation
        /// </summary>
        /// <param name="value"></param>
        void PlayVisualEffect(int value);
    }
}