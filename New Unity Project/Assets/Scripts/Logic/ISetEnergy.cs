public interface ISetEnergy
{
    /// <summary>
    /// Converts the energy value to speed units then updates the hero energy
    /// through the hero timer
    /// </summary>
    void StartAction(int energyValue);
}