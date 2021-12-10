using System.Collections;

namespace Logic
{
    public interface ISetAttack
    {
        /// <summary>
        /// Set attack text and color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IEnumerator StartAction(int value);
    }
}