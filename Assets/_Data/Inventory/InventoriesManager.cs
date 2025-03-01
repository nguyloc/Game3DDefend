using System.Collections.Generic;
using _Data.Inventory.Item;
using _Data.Scripts;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;


namespace _Data.Inventory
{
    public class InventoriesManager : LocSingleton<InventoriesManager>
    {
        [SerializeField] protected List<InventoryController> inventories;
        [SerializeField] protected List<ItemProfileSO> itemProfiles;

        protected override void Start()
        {
            base.Start();
            this.LoadGameData();
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadInventories();
            this.LoadItemProfiles();
        }
        
        public virtual void SaveGameData()
        {
            // Save gold
            ItemInventory itemGold = this.Currency().FindItem(ItemCode.Gold);
            if (itemGold != null) GameManager.Instance.Save.SaveInt("gold",itemGold.itemCount);
            
            // Save exp
            ItemInventory itemExp = this.Currency().FindItem(ItemCode.PlayerExp);
            if (itemExp != null) GameManager.Instance.Save.SaveInt("exp",itemExp.itemCount);
        }

        protected virtual void LoadGameData()
        {
            int goldCount = GameManager.Instance.Save.LoadInt("gold");
            int expCount = GameManager.Instance.Save.LoadInt("exp");
            
            // Add gold and exp 
            this.AddItem(ItemCode.Gold, goldCount);
            this.AddItem(ItemCode.PlayerExp, expCount);
            
            InvokeRepeating(nameof(this.SaveGameData), 5f, 5f);
        }

        
        protected virtual void LoadItemProfiles()
        {
            if (this.itemProfiles.Count > 0) return;
            ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
            this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
            Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
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

        public virtual void AddItem(ItemInventory itemInventory)
        {
            InventoryCodeName inventoryCodeName = itemInventory.ItemProfile.inventoryCodeName;
            InventoryController inventoryCtrl = InventoriesManager.Instance.GetByCodeName(inventoryCodeName);
            inventoryCtrl.AddItem(itemInventory);
        }
        
        public virtual void AddItem(ItemCode itemCode, int itemCount)
        {
            ItemProfileSO itemProfile = InventoriesManager.Instance.GetProfileByCode(itemCode);
            ItemInventory item = new(itemProfile, itemCount);
            this.AddItem(item);
        }

        public virtual void RemoveItem(ItemCode itemCode, int itemCount)
        {
            ItemProfileSO itemProfile = InventoriesManager.Instance.GetProfileByCode(itemCode);
            ItemInventory item = new(itemProfile, itemCount);
            this.RemoveItem(item);
        }

        public virtual void RemoveItem(ItemInventory itemInventory)
        {
            InventoryCodeName invCodeName = itemInventory.ItemProfile.inventoryCodeName;
            InventoryController inventoryController = InventoriesManager.Instance.GetByCodeName(invCodeName);
            inventoryController.RemoveItem(itemInventory);
        }

        public virtual int CheckGold()
        {
            ItemInventory itemGold = this.Currency().FindItem(ItemCode.Gold);
            return itemGold != null ? itemGold.itemCount : 0;
        }
        
        public virtual InventoryController Currency()
        {
            return this.GetByCodeName(InventoryCodeName.Currency);
        }
        
        public virtual InventoryController Items()
        {
            return this.GetByCodeName(InventoryCodeName.Items);
        }

    }
}
