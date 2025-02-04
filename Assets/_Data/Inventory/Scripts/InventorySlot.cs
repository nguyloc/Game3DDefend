using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace _Data.Inventory
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        public Image icon;
        public Item item;

        public void AddItem(Item newItem)
        {
            item = newItem;
            icon.sprite = item.icon;
            icon.enabled = true;
        }

        public void ClearSlot()
        {
            item = null;
            icon.sprite = null;
            icon.enabled = false;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                InventorySlot draggedSlot = eventData.pointerDrag.GetComponent<InventorySlot>();
                if (draggedSlot != null)
                {
                    Item draggedItem = draggedSlot.item;
                    draggedSlot.ClearSlot();
                    AddItem(draggedItem);
                }
            }
        }
    }
}
