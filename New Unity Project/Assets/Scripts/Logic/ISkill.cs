using JondiBranchLogic;
using ScriptableObjectScripts;
using UnityEngine;

namespace Logic
{
    public interface ISkill
    {
        /// <summary>
        /// Interface reference to skill logic
        /// </summary>
        ISkillLogic SkillLogic { get; }
        
        /// <summary>
        /// Interface reference to skill visual
        /// </summary>
        ISkillLogic SkillVisual { get; }
        
        /// <summary>
        /// Interface reference to skill preview
        /// </summary>
        ISkillPreview SkillPreview { get; }

        /// <summary>
        /// Interface reference to skill target collider
        /// </summary>
        ISkillTargetCollider SkillTargetCollider { get; }
        
        /// <summary>
        /// Interface reference to coroutine trees 
        /// </summary>
        ICoroutineTreesAsset CoroutineTrees { get; }
        
        /// <summary>
        /// Interface access to this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        
        //SET IN RUNTIME

        /// <summary>
        /// Interface reference to skill's hero
        /// get and set both used
        /// </summary>
        IHero Hero { get; set; }
        
        
    }
}