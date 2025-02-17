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
                this.items.Add(item);
                return;
            }
            itemExists.itemCount += item.itemCount;
        }
        
        public virtual ItemInventory FindItem(ItemCode itemCode)
        {
            foreach (ItemInventory itemInventory in this.items)
            {
                if (itemInventory.itemProfile.itemCode == itemCode) return itemInventory;
            }
            return null;
        }
    }
}
