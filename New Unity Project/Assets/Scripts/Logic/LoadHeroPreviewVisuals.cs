using System;
using UnityEngine;

namespace Logic
{
    public class LoadHeroPreviewVisuals : MonoBehaviour
    {
        private IHeroPreview _heroPreview;

        private void Awake()
        {
            _heroPreview = GetComponent<IHeroPreview>();
            
        }
        
        
        
        
    }
}
