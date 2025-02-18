using System;
using System.Collections.Generic;
using _Data.Inventory;
using _Data.Inventory.Item;
using _Data.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Data.UI.Inventory
{
    public class InventoryUI : LocSingleton<InventoryUI>
    {
        protected bool isShow = true;
        protected bool IsShow => isShow;

        [SerializeField]
        protected Transform showHide;
        
        [SerializeField] protected ButtonItemInventory defaultItemInventoryUI;
        protected List<ButtonItemInventory> buttonItems = new();

        protected void FixedUpdate()
        {
            this.ItemUpdating();
        }

        protected void LateUpdate()
        {
            this.HotkeyToogleInventory();
        }

        protected override void Start()
        {
            base.Start();
            this.Show();
            this.HideDefaultItemInventory();
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadButtonItemInventory();
            this.LoadShowHide();
        }
        
        protected virtual void LoadButtonItemInventory()
        {
            if (this.defaultItemInventoryUI != null) return;
            this.defaultItemInventoryUI = GetComponentInChildren<ButtonItemInventory>();
            Debug.Log(transform.name + " has no ButtonItemInventory component.", gameObject);
        }
        
        protected virtual void LoadShowHide()
        {
            if (this.showHide != null) return;
            this.showHide = transform.Find("ShowHide");
            Debug.Log(transform.name + " has no ShowHide component.", gameObject);
        }
        
        public virtual void Show()
        {
            this.showHide.gameObject.SetActive(true);
            this.isShow = true;
        }
        
        public virtual void Hide()
        {
            this.showHide.gameObject.SetActive(false);
            this.isShow = false;
        }
        
        public virtual void Toggle()
        {
            if (this.isShow)  this.Hide();
            else this.Show();
        }
        
        protected virtual void HideDefaultItemInventory()
        {
            this.defaultItemInventoryUI.gameObject.SetActive(false);
        }
        
        protected virtual void ItemUpdating()
        {
            if(!this.isShow) return;
            
            InventoryController itemInventoryController = InventoryManager.Instance.Items();
            foreach (ItemInventory itemInventory in itemInventoryController.Items)
            {
               ButtonItemInventory newButtonItem = this.GetExistItem(itemInventory);
               if (newButtonItem == null)
                {
                    newButtonItem = Instantiate(this.defaultItemInventoryUI, this.defaultItemInventoryUI.transform.parent, true);
                    newButtonItem.SetItem(itemInventory);
                    newButtonItem.gameObject.SetActive(true);
                    newButtonItem.name = itemInventory.GetItemName() + " - " + itemInventory.ItemID;
                    this.buttonItems.Add(newButtonItem);
                }
            }
        }
        
        protected virtual ButtonItemInventory GetExistItem (ItemInventory itemInventory)
        {
            foreach (ButtonItemInventory itemInventoryUI in this.buttonItems)
            {
                if (itemInventoryUI.ItemInventory.ItemID == itemInventory.ItemID) return itemInventoryUI;
            }
            return null;
        }
        
        protected virtual void HotkeyToogleInventory()
        {
            if (InputHotKey.Instance.IsToogleInventoryUI) this.Toggle();
        }
    }
}
