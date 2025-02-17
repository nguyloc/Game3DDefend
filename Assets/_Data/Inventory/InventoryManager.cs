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
        }

        protected override void Start()
        {
            base.Start();
            this.AddTestItems();
        }

        protected virtual void AddTestItems()
        {
            InventoryController inventoryController = this.GetByName(InventoryCodeName.Monies);
            
            ItemInventory gold = new ItemInventory();
            gold.itemProfile = this.GetProfileByCode(ItemCode.Gold);
            gold.itemCount = 100;
            inventoryController.AddItem(gold);
            
            ItemInventory gold2 = new ItemInventory();
            gold2.itemProfile = this.GetProfileByCode(ItemCode.Gold);
            gold2.itemCount = 50;
            inventoryController.AddItem(gold2);
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

        public virtual InventoryController GetByName(InventoryCodeName inventoryName)
        {
            foreach (InventoryController inventory in this.inventories)
            {
                if (inventory.GetName() == inventoryName) return inventory;
            }
            return null; 
        }
        
        public virtual ItemProfileSO GetProfileByCode(ItemCode itemCode)
        {
            foreach (ItemProfileSO itemProfile in this.itemProfiles)
            {
                if (itemProfile.itemCode == itemCode) return itemProfile;
            }
            return null; 
        }

        public virtual InventoryController Monies()
        {
            return this.GetByName(InventoryCodeName.Monies);
        }
        
        public virtual InventoryController Items()
        {
            return this.GetByName(InventoryCodeName.Items);
        }
    }
}
