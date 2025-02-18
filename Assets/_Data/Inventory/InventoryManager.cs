using System.Collections.Generic;
using _Data.Inventory.Item;
using _Data.Scripts;
using UnityEngine;
using com.cyborgAssets.inspectorButtonPro;

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
            return this.GetByCodeName(InventoryCodeName.Monies);
        }
        
        public virtual InventoryController Items()
        {
            return this.GetByCodeName(InventoryCodeName.Items);
        }
        
        protected virtual void LoadItemProfiles()
        {
            if (this.itemProfiles.Count > 0) return;
            ItemProfileSO[] itemProfileSOs = Resources.LoadAll<ItemProfileSO>("/");
            this.itemProfiles = new List<ItemProfileSO>(itemProfileSOs);
            Debug.Log(transform.name + ": LoadItemProfiles", gameObject);
        }
    }
}
