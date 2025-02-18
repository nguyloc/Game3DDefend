using System.Collections.Generic;
using _Data.Inventory.Item;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Inventory
{
    public abstract class InventoryController : LocMonoBehaviour
    {
        
        [SerializeField] protected List<ItemInventory> items = new();
        public List<ItemInventory> Items => items;
        
        public abstract InventoryCodeName GetName();
    
        public virtual void AddItem(ItemInventory item)
        {
            ItemInventory itemExists = this.FindItem(item.itemProfile.itemCode);
            if (!item.itemProfile.isStackable || itemExists == null)
            {
                item.itemId = Random.Range(0, 1000);
                this.items.Add(item);
                return;
            }
            itemExists.itemCount += item.itemCount;
        }
        
        public virtual bool RemoveItem(ItemInventory item)
        {
            ItemInventory itemExists = this.FindItemNotEmpty(item.itemProfile.itemCode);
            if (itemExists == null) return false;
            if (itemExists.itemCount < item.itemCount) return false;
            itemExists.itemCount -= item.itemCount;
            if(itemExists.itemCount == 0) this.items.Remove(itemExists);
            return true;
        }
        
        public virtual ItemInventory FindItem(ItemCode itemCode)
        {
            foreach (ItemInventory itemInventory in this.items)
            {
                if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
            }
            return null;
        }
        
        public virtual ItemInventory FindItemNotEmpty(ItemCode itemCode)
        {
            foreach (ItemInventory itemInventory in this.items)
            {
                if (itemInventory.itemProfile.itemCode != itemCode) continue;
                if (itemInventory.itemProfile.itemCode > 0) return itemInventory;
            }
            return null;
        }
    }
}
