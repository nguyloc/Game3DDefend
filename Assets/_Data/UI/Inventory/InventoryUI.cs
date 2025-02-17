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
        
        [SerializeField] protected ButtonItemInventory defaultItemInventoryUI;
        protected List<ButtonItemInventory> buttonItems = new();

        protected void FixedUpdate()
        {
            this.ItemUpdating();
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
        }
        
        protected virtual void LoadButtonItemInventory()
        {
            if (this.defaultItemInventoryUI != null) return;
            this.defaultItemInventoryUI = GetComponentInChildren<ButtonItemInventory>();
            Debug.Log(transform.name + " has no ButtonItemInventory component.", gameObject);
        }
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
            this.isShow = true;
        }
        
        public virtual void Hide()
        {
            gameObject.SetActive(false);
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
            InventoryController itemInventoryController = InventoryManager.Instance.Items();
            foreach (ItemInventory itemInventory in itemInventoryController.Items)
            {
               // ButtonItemInventory newItemUI = this.GetExistItem();
               // if (newItemUI = null)
                {
                    // newItemUI = Instantiate(this.defaultItemInventoryUI);
                    // newItemUI.transform.parent = this.defaultItemInventoryUI.transform.parent;
                    // newItemUI.gameObject.SetActive(true);
                }
            }
        }
        
        protected virtual ButtonItemInventory GetExistItem (ItemInventory itemInventory)
        {
            foreach (ButtonItemInventory itemInventoryUI in this.buttonItems)
            {
                //if (itemInventoryUI.ItemInventory == itemInventory) return itemInventoryUI;
            }
            return null;
        }
    }
}
