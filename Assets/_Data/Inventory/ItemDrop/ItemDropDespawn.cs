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
            InventoryManager.Instance.AddItem(itemDropController.ItemCode, itemDropController.ItemCount);
            base.DoDespawn();
        }
    }
}
