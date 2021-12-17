using System.Collections.Generic;
using UnityEngine;

namespace AssetsScriptableObjects
{
    [CreateAssetMenu(fileName = "TeamHeroes", menuName = "Assets/TeamHeroes")]
    public class TeamHeroesAsset : ScriptableObject, ITeamHeroesAsset
    {
        /// <summary>
        /// List of hero assets in a team.
        /// Assigned in the inspector 
        /// </summary>
        [SerializeField] 
        private List<Object> teamHeroes = new List<Object>();
        
        /// <summary>
        /// Returns the list of team heroes
        /// </summary>
        /// <returns></returns>
        public List<IHeroAsset> TeamHeroes()
        {
            var heroes = new List<IHeroAsset>();

            foreach (var heroObject in teamHeroes)
            {
                heroes.Add(heroObject as IHeroAsset);
            }
            return heroes;
        }




    }
        
        








    }

