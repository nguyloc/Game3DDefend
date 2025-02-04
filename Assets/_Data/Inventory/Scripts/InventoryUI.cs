using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        public Transform itemsParent;
        public InventorySlot[] slots;

        void Start()
        {
            slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        }

        public void AddItem(Item item)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == null)
                {
                    slot.AddItem(item);
                    return;
                }
            }
        }

        public void RemoveItem(Item item)
        {
            foreach (InventorySlot slot in slots)
            {
                if (slot.item == item)
                {
                    slot.ClearSlot();
                    return;
                }
            }
        }
    }
}
