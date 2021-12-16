using System.Collections.Generic;
using JondiBranchLogic;
using UnityEngine;

namespace Logic
{
    public interface ITurnController
    {
        /// <summary>
        /// 100% percent timer full in speed units
        /// </summary>
        int TimerFull { get; }
        
        /// <summary>
        /// Energy increase per time "tick" (delta time)
        /// </summary>
        int SpeedConstant { get; }
        
        /// <summary>
        /// Stops all hero timers when true
        /// </summary>
        bool FreezeTimers { get; set; }

        ICoroutineTreesAsset CoroutineTrees { get; }
        
        //SET IN RUNTIME

        /// <summary>
        /// Reference to the battle scene manager
        /// Set during initialization
        /// </summary>
        IBattleSceneManager BattleSceneManager { get; set; }

        /// <summary>
        /// Returns this as a game object
        /// </summary>
        GameObject ThisGameObject { get; }
        
        /// <summary>
        ///Used for adding heroes to the active heroes list 
        /// </summary>
        List<Object> ActiveHeroesList { get; }

        /// <summary>
        ///  Returns list of active heroes
        /// </summary>
        List<IHero> ActiveHeroes { get; }
        
        /// <summary>
        ///  Reference to sort heroes by energy
        /// </summary>
        ISortHeroesByEnergy SortHeroesByEnergy { get; }
        
        /// <summary>
        /// Updates all living heroes' hero timers
        /// </summary>
        IUpdateHeroTimers UpdateHeroTimers { get; }

    }
}