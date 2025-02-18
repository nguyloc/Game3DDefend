using System;
using UnityEngine;

namespace _Data.Scripts
{
    public class InputHotKey : LocSingleton<InputHotKey>
    {
        protected bool isToogleInventoryUI = false;
        public bool IsToogleInventoryUI => isToogleInventoryUI;

        protected void Update()
        {
            this.OpenInventoryUI();
        }
        
        protected virtual void OpenInventoryUI()
        {
           this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
        }
    }
}
