using UnityEngine;

public class ScenePrefabs : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        this.gameObject.SetActive(true);
    }
        
        
        
}