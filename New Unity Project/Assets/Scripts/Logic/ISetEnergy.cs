namespace Logic
{
    public interface ISetEnergy
    {
        /// <summary>
        /// Converts the energy value to speed units then updates the hero energy
        /// through the hero timer
        /// </summary>
        void SetToValue(int energyValue);
        
        /// <summary>
        /// Resets the energy and speed units to zero
        /// </summary>
        void ResetToZero();
    }
}