using JondiBranchLogic;
using UnityEngine;

namespace Logic
{
    public interface IPlayer
    {
        /// <summary>
        /// Interface access to alive heroes
        /// </summary>
        IAliveHeroes AliveHeroes { get; }
        
        /// <summary>
        /// Interface access to dead heroes
        /// </summary>
        IDeadHeroes DeadHeroes { get; }
        
        /// <summary>
        /// Interface access to hero skills
        /// </summary>
        ISkillsAllHeroes SkillsAllHeroes { get; }
        
        /// <summary>
        /// Interface access to portraits
        /// </summary>
        IPortraits Portraits { get; }

        /// <summary>
        /// Interface access to display skill
        /// </summary>
        IDisplaySkills DisplaySkills { get; }

        /// <summary>
        /// Interface access to display portraits
        /// </summary>
        IDisplayPortraits DisplayPortraits { get; }

        /// <summary>
        /// Interface access to this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        ///  Global Main and Visual trees reference
        /// </summary>
        ICoroutineTreesAsset CoroutineTrees { get; }
        
        /// <summary>
        /// Initialize player heroes component reference
        /// </summary>
        IInitializePlayerHeroes InitializePlayerHeroes { get; }
        
        /// <summary>
        /// Reference to Battle scene manager
        /// </summary>
        IBattleSceneManager BattleSceneManager { get; set; }
        
        /// <summary>
        /// Reference to hero and skill previews
        /// </summary>
        IHeroAndSkillPreviews HeroAndSkillPreviews { get; }
        
        /// <summary>
        /// The enemy of the current player
        /// </summary>
        IPlayer OtherPlayer { get; set;}

    }
}