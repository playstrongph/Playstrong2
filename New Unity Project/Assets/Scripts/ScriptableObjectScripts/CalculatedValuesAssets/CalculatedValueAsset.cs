using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.CalculatedValuesAssets
{
    public class CalculatedValueAsset : ScriptableObject, ICalculatedValueAsset
    {

        public float CalculatedValue { get; set; }

        public List<IHero> CalculatedHeroes { get; set; }

        public virtual void GetCalculatedValue(IHero heroBasis)
        {
           
        }
        
        public virtual List<IHero> GetCalculatedHeroList(IHero heroBasis)
        {
            var heroes = new List<IHero>();
            return heroes;
        }
        
        

        protected List<int> ShuffleList(List<int> values)
        {
            var randomList = values;
            
            //Randomize the List
            for (int i = 0; i < randomList.Count; i++) 
            {
                var temp = randomList[i];
                int randomIndex = Random.Range(i, randomList.Count);
                randomList[i] = randomList[randomIndex];
                randomList[randomIndex] = temp;
            }

            return randomList;
        }



    }
}
