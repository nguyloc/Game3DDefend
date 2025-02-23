using System;
using UnityEngine;

namespace _Data.Scripts
{
    public class InputHotKey : LocSingleton<InputHotKey>
    {
        protected bool isToogleInventoryUI = false;
        public bool IsToogleInventoryUI => isToogleInventoryUI;

        public bool isToogleMusic = false;
        public bool isToogleSetting = false;
        
        protected void Update()
        {
            this.OpenInventoryUI();
            this.ToogleMusic();
            this.ToogleSetting();
        }
        
        protected virtual void OpenInventoryUI()
        {
           this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
        }
        
        protected virtual void ToogleMusic()
        {
            this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
        }
        
        protected virtual void ToogleSetting()
        {
            this.isToogleSetting = Input.GetKeyUp(KeyCode.S);
        }
    }
}
