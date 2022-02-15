using System;
using ScriptableObjectScripts.HeroLifeStatusAssets;
using UnityEngine;

namespace Logic
{
    public class HeroDies : MonoBehaviour
    {
       [SerializeField][RequireInterfaceAttribute.RequireInterface(typeof(IHeroLifeStatusAsset))]
       private ScriptableObject heroLifeStatus;
       
       public IHeroLifeStatusAsset HeroLifeStatus
       {
           get => heroLifeStatus as IHeroLifeStatusAsset;
           set => heroLifeStatus = value as ScriptableObject;
       }

       private IHeroLogic _heroLogic;

       private void Awake()
       {
           _heroLogic = GetComponent<IHeroLogic>();
       }
       
       
       
    }
}
