using AssetsScriptableObjects;
using JondiBranchLogic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts
{
    public interface IBattleSceneSettingsAsset
    {
        //PREFABS
        
        /// <summary>
        /// Reference to the turn controller prefab
        /// </summary>
        ITurnController TurnController { get; }

        /// <summary>
        /// Reference to the game board prefab
        /// </summary>
        IGameBoard GameBoard { get; }

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
        IHeroSkills HeroSkillsPrefab { get; }
        
        /// <summary>
        /// Interface access to to hero portrait prefab.
        /// Set in the inspector.
        /// </summary>
        IHeroPortrait HeroPortraitPrefab { get; }
        
        /// <summary>
        /// End turn button prefab
        /// </summary>
        IEndTurnButton EndTurnButtonPrefab { get; }

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
        /// End turn button board position
        /// </summary>
        Vector3 EndTurnButtonPosition { get; }

        /// <summary>
        /// Interface access to coroutine tress asset
        /// </summary>
        CoroutineTreesAsset CoroutineTreesAsset { get; }
        
        /// <summary>
        /// Reference to ITeamHeroesAsset MainPlayerTeamHeroes
        /// </summary>
        ITeamHeroesAsset MainPlayerTeamHeroes { get; }
        
        /// <summary>
        /// Reference to ITeamHeroesAsset EnemyPlayerTeamHeroes
        /// </summary>
        ITeamHeroesAsset EnemyPlayerTeamHeroes { get; }

    }
    
    
    
}