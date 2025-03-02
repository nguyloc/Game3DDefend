using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Data.Inventory.Item
{
    [CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
    public class ItemProfileSO : ScriptableObject
    {
        public InventoryCodeName inventoryCodeName;
        public ItemCode itemCode;
        public Image itemIcon;
        public string itemName;
        public bool isStackable = false;
    }
}