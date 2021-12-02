using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface ITauntFrame
    {
        Image ActionGlow { get; }
        Image EnemyGlow { get; }
        Image AllyGlow { get; }
        Image FrameImage { get; }
    }
}