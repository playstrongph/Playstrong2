using System.Collections;

namespace Logic
{
    public interface ISetFightingSpirit
    {
        /// <summary>
        /// Set fighting spirit value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IEnumerator StartAction(int value);
    }
}