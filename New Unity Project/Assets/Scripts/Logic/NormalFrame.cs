using UnityEngine;
using UnityEngine.UI;


namespace Logic
{
    public class NormalFrame : MonoBehaviour, INormalFrame
    {
        [SerializeField] private Image actionGlow;
        public Image ActionGlow { get => actionGlow; set => actionGlow = value; }
        
        [SerializeField] private Image enemyGlow;
        public Image EnemyGlow { get => enemyGlow; set => enemyGlow = value; }
        
        [SerializeField] private Image allyGlow;
        public Image AllyGlow { get => allyGlow; set => allyGlow = value; }
        
        [SerializeField] private Image frameImage;
        public Image FrameImage { get => frameImage; set => frameImage = value; }
    }
}
