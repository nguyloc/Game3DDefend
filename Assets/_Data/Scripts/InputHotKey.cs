using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Data.Scripts
{
    public class InputHotKey : LocSingleton<InputHotKey>
    {
        protected bool isToogleInventoryUI = false;
        public bool IsToogleInventoryUI => isToogleInventoryUI;

        public bool isToogleMusic = false;
        public bool isToogleSetting = false;
        
        [SerializeField] protected KeyCode keyCode;
        public KeyCode KeyCode => keyCode;

        [SerializeField] protected bool isPlaceTower;
        public bool IsPlaceTower => isPlaceTower;
        
        protected void Update()
        {
            this.OpenInventoryUI();
            this.ToogleMusic();
            this.ToogleSetting();
            this.ToogleNumber();
        }
        
        protected virtual void OpenInventoryUI()
        {
           this.isToogleInventoryUI = Input.GetKeyUp(KeyCode.I);
        }
        
        protected virtual void ToogleSetting()
        {
            this.isToogleSetting = Input.GetKeyUp(KeyCode.O);
        }
        
        protected virtual void ToogleMusic()
        {
            this.isToogleMusic = Input.GetKeyUp(KeyCode.M);
        }
        
        protected virtual void ToogleNumber()
        {
            this.isPlaceTower = Input.GetKeyUp(KeyCode.Mouse0);
            
            for (int i = 1; i <= 5; i++)
            {
                KeyCode key = (KeyCode) Enum.Parse(typeof(KeyCode), "Alpha" + i);
                if (Input.GetKeyUp(key))
                {
                    this.keyCode = this.keyCode == key ? KeyCode.None : key;
                    break;
                }
            }
        }
    }
}
