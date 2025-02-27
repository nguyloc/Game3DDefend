using UnityEngine;

namespace _Data.SaveManager
{
    /// <summary>
    /// Save manager implementation using Unity's PlayerPrefs.
    /// </summary>
    public class PlayerPrefsSaveManager : SaveManager
    {
        public override void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save(); // Ensure data is written immediately
        }

        public override int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public override void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public override void ClearAllData()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
