using UnityEngine;

public class DisplayPortraits : MonoBehaviour, IDisplayPortraits
{
    /// <summary>
    /// Reference to display portrait as a game object
    /// </summary>
    public GameObject ThisGameObject => this.gameObject;
}