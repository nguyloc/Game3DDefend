using _Data.Inventory.Item;
using _Data.Spawner.Despawn;
using UnityEngine;

namespace _Data.Inventory.ItemDrop
{
    public class ItemDropDespawn : Despawn<ItemDropController>
    {
        public override void DoDespawn()
        {
            ItemDropController itemDropController = (ItemDropController) this.parent;
            
            ItemInventory item = new();
            item.itemProfile = InventoryManager.Instance.GetProfileByCode(itemDropController.ItemCode);
            item.itemCount =  itemDropController.ItemCount;
            InventoryManager.Instance.GetByCodeName(itemDropController.InventoryCodeName).AddItem(item);
            
            base.DoDespawn();
        }
    }
}
