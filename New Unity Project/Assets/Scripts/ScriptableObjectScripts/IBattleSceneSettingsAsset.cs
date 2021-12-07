using JondiBranchLogic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts
{
    public interface IBattleSceneSettingsAsset
    {
        //PREFABS
        
        /// <summary>
        /// Interface access to to player prefab.
        /// Set in the inspector.
        /// </summary>
        IPlayer PlayerPrefab { get; }
        
        /// <summary>
        /// Interface access to to hero prefab.
        /// Set in the inspector.
        /// </summary>
        IHero HeroPrefab { get; }
        
        /// <summary>
        /// Interface access to to skill prefab.
        /// Set in the inspector.
        /// </summary>
        ISkill SkillPrefab { get; }
        
        /// <summary>
        /// Interface access to to skill prefab.
        /// Set in the inspector.
        /// </summary>
        IHeroSkills HeroSkills { get; }
        
        /// <summary>
        /// Interface access to to hero portrait prefab.
        /// Set in the inspector.
        /// </summary>
        IPortrait HeroPortrait { get; }

        //TRANSFORMS
        
        /// <summary>
        /// Interface access to main players'
        /// heroes board position.
        /// </summary>
        Vector3 AllyHeroesPosition { get; }
        
        /// <summary>
        /// Interface access to enemy players'
        /// heroes board position.
        /// </summary>
        Vector3 EnemyHeroesPosition { get; }

        /// <summary>
        /// Interface access to hero's 
        /// skills board position.
        /// </summary>
        Vector3 SkillsPosition { get; }

        /// <summary>
        /// Interface access to hero's 
        /// display skills board position.
        /// </summary>
        Vector3 DisplaySkillsPosition { get; }
        
        /// <summary>
        /// Interface access to hero's 
        /// portrait board position.
        /// </summary>
        Vector3 PortraitPosition { get; }

        /// <summary>
        /// Interface access to hero's 
        /// display portrait board position.
        /// </summary>
        Vector3 DisplayPortraitPosition { get; }
        
        /// <summary>
        /// Interface access to hero's 
        /// skill preview board position.
        /// </summary>
        Vector3 SkillPreviewPosition { get; }
        
        /// <summary>
        /// Interface access to hero  
        /// preview board position.
        /// </summary>
        Vector3 HeroPreviewPosition { get; }
        
        /// <summary>
        /// Interface access to coroutine tress asset
        /// </summary>
        CoroutineTreesAsset CoroutineTreesAsset { get; }

    }
    
    
    
}