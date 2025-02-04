using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        public InventoryUI inventoryUI;

        public void DropItem(Item item)
        {
            // Drop logic here
            inventoryUI.RemoveItem(item);
            Debug.Log("Dropped: " + item.itemName);
        }

        public void DeleteItem(Item item)
        {
            // Delete logic here
            inventoryUI.RemoveItem(item);
            Debug.Log("Deleted: " + item.itemName);
        }
    }
}
