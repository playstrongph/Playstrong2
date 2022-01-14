using Logic;

namespace Animation
{
    public interface IGameVisualEffects
    {
        /// <summary>
        /// Play visual effect, int argument
        /// </summary>
        /// <param name="value"></param>
        void PlayVisualEffect(int value);

        /// <summary>
        /// Play visual effect, hero argument
        /// </summary>
        /// <param name="hero"></param>
        void PlayVisualEffect(IHero hero);
    }
}