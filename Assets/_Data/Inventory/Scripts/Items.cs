using UnityEngine;

namespace _Data.Inventory
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
    public class Item : ScriptableObject
    {
        public string itemName;
        public Sprite icon;
        public bool isEquippable;
        public bool isUsable;
    }
}
