using System.Collections;

public interface IInitializeTurnController
{
    /// <summary>
    /// Instantiates and initializes the turn controller
    /// </summary>
    /// <returns></returns>
    IEnumerator StartAction();
}