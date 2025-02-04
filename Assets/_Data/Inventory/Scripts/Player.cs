using UnityEngine;

namespace _Data.Inventory
{
    public class Player : MonoBehaviour
    {
        public InventoryUI inventoryUI;

        public void EquipItem(Item item)
        {
            if (item.isEquippable)
            {
                // Equip logic here
                Debug.Log("Equipped: " + item.itemName);
            }
        }

        public void UseItem(Item item)
        {
            if (item.isUsable)
            {
                // Use logic here
                Debug.Log("Used: " + item.itemName);
            }
        }
    }
}
