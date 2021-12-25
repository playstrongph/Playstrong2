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
        bool ActiveHeroFound { get; set; }

        ICoroutineTreesAsset CoroutineTrees { get; }
        
        //SET IN RUNTIME
        
        /// <summary>
        /// The hero currently taking a turn
        /// </summary>
        IHero CurrentActiveHero { get; set; }

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
            
        /// <summary>
        /// Sets the current active hero
        /// </summary>
        ISetCurrentActiveHero SetCurrentActiveHero { get;}
        
        /// <summary>
        /// Before hero starts the turn actions
        /// </summary>
        IBeforeHeroStartTurn BeforeHeroStartTurn { get; }
        
        /// <summary>
        /// Hero Start Turn PHASE
        /// </summary>
        IHeroStartTurn HeroStartTurn { get; }
        
        /// <summary>
        /// Hero End turn PHASE
        /// </summary>
        IHeroEndTurn HeroEndTurn { get; }

        /// <summary>
        /// Add or remove heroes to the active heroes list
        /// </summary>
        ISetActiveHeroes SetActiveHeroes { get; }
        
        /// <summary>
        /// First time combat start
        /// </summary>
        void StartBattle();
        
        

    }
}