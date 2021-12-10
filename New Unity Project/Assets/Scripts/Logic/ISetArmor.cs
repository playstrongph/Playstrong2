using System.Collections;

namespace Logic
{
    public interface ISetArmor
    {
        /// <summary>
        /// Set armor text and color
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IEnumerator StartAction(int value);
    }
}