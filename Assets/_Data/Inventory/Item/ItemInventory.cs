using System;
using UnityEngine;

namespace _Data.Inventory.Item
{
    [Serializable]
    public class ItemInventory
    {
        public int itemId;
        public string itemName;
        public ItemProfileSO itemProfile;
        public int itemCount;
    }
}
 