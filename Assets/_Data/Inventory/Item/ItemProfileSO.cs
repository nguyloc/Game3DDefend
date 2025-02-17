using UnityEngine;
using UnityEngine.Serialization;

namespace _Data.Inventory.Item
{
    [CreateAssetMenu(fileName = "ItemProfile", menuName = "ScriptableObjects/ItemProfile", order = 1)]
    public class ItemProfileSO : ScriptableObject
    {
        [FormerlySerializedAs("itemCodeName")]
        public ItemCode itemCode;
        public string itemName;
        public bool isStackable = false;
    }
}