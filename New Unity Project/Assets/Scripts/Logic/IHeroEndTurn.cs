using System.Collections;

namespace Logic
{
    public interface IHeroEndTurn
    {
        /// <summary>
        /// Call hero end turn subscribers, set current hero inactive, remove active hero
        /// visuals
        /// </summary>
        /// <returns></returns>
        IEnumerator StartAction();
    }
}