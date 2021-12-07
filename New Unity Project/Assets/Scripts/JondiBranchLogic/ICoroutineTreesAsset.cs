namespace JondiBranchLogic
{
    public interface ICoroutineTreesAsset
    {
        ICoroutineTree MainLogicTree { get; set; }

        ICoroutineTree MainVisualTree { get; set; }

    }
}