using System.Collections.Generic;
using UnityEngine;


namespace Logic
{
    public class Portraits : MonoBehaviour, IPortraits
    {   
        /// <summary>
        /// Reference to portrait as a game object
        /// </summary>
        public GameObject ThisGameObject => this.gameObject;

        
    }
}
