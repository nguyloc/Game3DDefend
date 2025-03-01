using _Data.Inventory;
using _Data.Inventory.Item;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;

namespace _Data.Scripts
{
    public class GameManager : LocSingleton<GameManager>
    {
        [SerializeField] protected SaveManager.SaveManager save;
        public SaveManager.SaveManager Save => save;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSaveManager();
        }
        
        
        protected virtual void LoadSaveManager()
        {
            if(this.save != null) return;
            this.save = GetComponentInChildren<SaveManager.SaveManager>();
            Debug.Log(transform.name + " loaded save manager: " ,gameObject);
        }
        
        [ProButton]
        public virtual void DeleteSaveData()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }

        public virtual void QuitGame()
        {
            InventoriesManager.Instance.SaveGameData();
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit(); 
#endif
        }
    }
}
