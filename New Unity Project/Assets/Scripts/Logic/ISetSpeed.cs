using System.Collections;

namespace Logic
{
    public interface ISetSpeed
    {
        /// <summary>
        /// Set hero speed value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IEnumerator StartAction(int value);
    }
}