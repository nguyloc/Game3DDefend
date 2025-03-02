using _Data.Scripts;

namespace _Data.SaveManager
{
    /// <summary>
    /// Abstract base class for save managers, allowing multiple save implementations.
    /// </summary>
    public abstract class SaveManager : LocMonoBehaviour
    {
        public abstract void SaveInt(string key, int value);
        public abstract int LoadInt(string key, int defaultValue = 0);
        public abstract void DeleteKey(string key);
        public abstract void ClearAllData();
    }
}
