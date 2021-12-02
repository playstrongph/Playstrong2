using UnityEngine.UI;

namespace Logic
{
    public interface INormalFrame
    {
        Image ActionGlow { get; }
        Image EnemyGlow { get; }
        Image AllyGlow { get; }
        Image FrameImage { get; }
    }
}