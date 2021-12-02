using ScriptableObjectScripts;

namespace Logic
{
    public interface IHero
    {
        /// <summary>
        /// Interface access to heroLogic
        /// "Set" parameter is not used
        /// </summary>
        IHeroLogic HeroLogic { get; }
        
        /// <summary>
        /// Interface access to HeroVisual
        /// "Set" parameter is not used
        /// </summary>
        IHeroVisual HeroVisual { get; }

        /// <summary>
        /// Interface access to HeroPreview
        /// "Set" parameter is not used
        /// </summary>
        IHeroPreview HeroPreview { get; }
        
        /// <summary>
        /// Interface access to Hero's target collider
        /// "Set" parameter is not used
        /// </summary>
        ITargetCollider TargetCollider { get; }

        /// <summary>
        /// Interface access to coroutine trees scriptable Object
        /// "Set" parameter is not used
        /// </summary>
        ICoroutineTreesAsset CoroutineTrees { get; }


        /// <summary>
        /// Interface access to list of heroSkills
        /// </summary>
        IHeroSkills HeroSkills { get; set; }
        
        /// <summary>
        /// Interface access to list of statusEffects
        /// </summary>
        IStatusEffects StatusEffects { get; set; }
        
        /// <summary>
        /// Hero portrait set during initialization
        /// Same prefab used as panel portrait
        /// </summary>
        IHeroPortrait HeroPortrait { get; set; }
        
        /// <summary>
        /// Hero portrait set during initialization
        /// Same prefab used as portrait
        /// </summary>
        IPanelPortrait PanelHeroPortrait { get; set; }

        /// <summary>
        /// Panel skills set during initialization
        /// Same prefab used as hero skills
        /// </summary>
        IPanelSkills PanelSkills { get; set; }


    }
}