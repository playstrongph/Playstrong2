using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic
{
    public interface IHeroPreview
    {
        /// <summary>
        /// Interface reference to Hero
        /// </summary>
        IHero Hero { get; }

        /// <summary>
        /// Interface access to hero preview canvas
        /// "Set" parameter is not used
        /// </summary>
        Canvas PreviewCanvas { get;}

        /// <summary>
        /// Interface access to hero preview frame
        /// "Set" parameter is not used
        /// </summary>
        Image Frame { get; }
        
        /// <summary>
        /// Interface access to hero preview graphic
        /// "Set" parameter is not used
        /// </summary>
        IHeroPreviewGraphic HeroPreviewGraphic { get; }
        
        /// <summary>
        /// Interface access to hero preview text
        /// "Set" parameter is not used
        /// </summary>
        IHeroPreviewName HeroPreviewName { get; }
        
        /// <summary>
        /// Interface access to hero preview attack
        /// "Set" parameter is not used
        /// </summary>
        IHeroPreviewAttack HeroPreviewAttack { get;  }
        
        /// <summary>
        /// Interface access to hero preview attack
        /// "Set" parameter is not used
        /// </summary>
        IHeroPreviewHealth HeroPreviewHealth { get; }
        
        /// <summary>
        /// Interface access to hero preview attack
        /// "Set" parameter is not used
        /// </summary>
        IHeroPreviewChance HeroPreviewChance { get; }
        
        /// <summary>
        /// Interface access to preview status effects transform
        /// "Set" parameter is not used
        /// </summary>
        Transform PreviewStatusEffects { get; }

    }
}