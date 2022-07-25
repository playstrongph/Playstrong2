using System.Collections.Generic;
using Logic;
using UnityEngine;

namespace ScriptableObjectScripts.CalculatedValuesAssets
{
    [CreateAssetMenu(fileName = "RandomListNumberCalculatedValue", menuName = "Assets/CalculatedValues/RandomListNumberCalculatedValue")]
    public class RandomListNumberCalculatedValueAsset : CalculatedValueAsset
    {
        [SerializeField] private List<int> listValues = new List<int>();
        
        public override void GetCalculatedValue(IHero heroBasis)
        {
            CalculatedValue = ShuffleList()[0];
        }
        
        
        private List<int> ShuffleList()
        {
            //Randomize the List
            for (var i = 0; i < listValues.Count; i++) 
            {
                var temp = listValues[i];
                var randomIndex = Random.Range(i, listValues.Count);
                listValues[i] = listValues[randomIndex];
                listValues[randomIndex] = temp;
            }

            return listValues;
        }
    }
}
