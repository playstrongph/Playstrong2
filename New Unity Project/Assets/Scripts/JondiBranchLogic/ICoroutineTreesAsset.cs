namespace JondiBranchLogic
{
    public interface ICoroutineTreesAsset
    {
        /// <summary>
        /// Interface access to MainLogicTree
        /// </summary>
        ICoroutineTree MainLogicTree { get; set; }

        /// <summary>
        /// Interface access to MainVisualTree
        /// </summary>
        ICoroutineTree MainVisualTree { get; set; }

    }
}