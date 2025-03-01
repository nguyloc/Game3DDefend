using System.Collections.Generic;
using _Data.Inventory.Item;
using _Data.Scripts;
using UnityEngine;


namespace _Data.Inventory
{
    public class InventoryManager : LocSingleton<InventoryManager>
    {
        [SerializeField] protected List<InventoryController> inventories;
        
        [SerializeField] protected List<ItemProfileSO> itemProfiles;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadInventories();
            this.LoadItemProfiles();
        }
        
        protected virtual void LoadInventories()
        {
            if (this.inventories.Count > 0) return;
            foreach (Transform child in transform)
            {
                InventoryController inventoryController = child.GetComponent<InventoryController>();
                if (inventoryController == null) continue;
                this.inventories.Add(inventoryController);
            }
            Debug.Log(transform.name + ": LoadInventories", gameObject);
        }

        public virtual InventoryController GetByCodeName(InventoryCodeName inventoryName)
        {
            foreach (InventoryController inventory in this.inventories)
            {
                if (inventory.GetName() == inventoryName) return inventory;
            }
            return null; 
        }
        
        public virtual ItemProfileSO GetProfileByCode(ItemCode itemCodeName)
        {
            foreach (ItemProfileSO itemProfile in this.itemProfiles)
            {
                if (itemProfile.itemCode == itemCodeName) return itemProfile;
            }
            return null; 
        }

        public virtual InventoryController Monies()
        {
            return this.GetByCodeName(InventoryCodeName.Currency);
        }
        
        public virtual InventoryController Items()
        {
            return this.GetByCodeName(InventoryCodeName.Items);
        }
        
        public virtual void AddItem(ItemInventory itemInventory)
        {
            InventoryCodeName inventoryCodeName = itemInventory.ItemProfile.inventoryCodeName;
            InventoryController inventoryCtrl = InventoryManager.Instance.GetByCodeName(inventoryCodeName);
            inventoryCtrl.AddItem(itemInventory);
        }
        
        public virtual void AddItem(ItemCode itemCode, int itemCount)
        {
            ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            ItemInventory item = new(itemProfile, itemCount);
            this.AddItem(item);
        }

        public virtual void RemoveItem(ItemCode itemCode, int itemCount)
        {
            ItemProfileSO itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            ItemInventory item = new(itemProfile, itemCount);
            this.RemoveItem(item);
        }

        public virtual void RemoveItem(ItemInventory itemInventory)
        {
            InventoryCodeName invCodeName = itemInventory.ItemProfile.inventoryCodeName;
            InventoryController inventoryController = InventoryManager.Instance.GetByCodeName(invCodeName);
            inventoryController.RemoveItem(itemInventory);
        }
        
        // Lưu ý: Chỉ làm với file nhỏ, làm với file âm thanh hay map là cook :)))
        // Tự động hóa add ItemProfileSO vào inspector
        protected virtual void LoadItemProfiles()
        {
            if (this.itemProfiles.Count > 0) return;
            ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
            this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
            Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
        }
    }
}
