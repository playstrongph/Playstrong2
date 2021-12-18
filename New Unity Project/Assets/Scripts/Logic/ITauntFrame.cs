using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

namespace Logic
{
    public interface ITauntFrame
    {
        Image ActionGlow { get; }
        Image EnemyGlow { get; }
        Image AllyGlow { get; }
        Image FrameImage { get; }
        
        //2D LIGHTS
        Light2D ActionLight { get; }
        Light2D EnemyLight { get; }
        Light2D AllyLight { get; }
    }
}