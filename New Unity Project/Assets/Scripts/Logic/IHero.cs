using System;
using System.Collections.Generic;
using JondiBranchLogic;
using ScriptableObjectScripts;
using UnityEngine;

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
        /// Interface access to Hero status effects
        /// "Set" parameter is not used
        /// </summary>
        IHeroStatusEffects HeroStatusEffects { get; }

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

        
        //SET IN RUNTIME

        String HeroName { get; set; }

        /// <summary>
        /// References hero's skills
        /// </summary>
        IHeroSkills HeroSkills { get; set; }
        
        /// <summary>
        /// Panel skills set during initialization
        /// Same prefab used as hero skills
        /// </summary>
        IDisplaySkills DisplayHeroSkills { get; set; }
        
       
        /// <summary>
        /// Hero portrait set during initialization
        /// Same prefab used as panel portrait
        /// </summary>
        IHeroPortrait HeroPortrait { get; set; }
        
        /// <summary>
        /// Display hero portrait set during initialization
        /// Same prefab used as portrait
        /// </summary>
        IHeroPortrait DisplayHeroPortrait { get; set; }

       
        
        /// <summary>
        /// Interface access to this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        /// The player this hero belongs to
        /// </summary>
        IPlayer Player { get; set; }
        
        /// <summary>
        /// Initialize hero portrait reference
        /// </summary>
        IInitializeHeroPortrait InitializeHeroPortrait { get; }
        
        /// <summary>
        /// Initializes the hero skills and display hero skills
        /// </summary>
        IInitializeHeroSkills InitializeHeroSkills { get; }


    }
}