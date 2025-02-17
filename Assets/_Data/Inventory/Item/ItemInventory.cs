using System;
using UnityEngine;

namespace _Data.Inventory.Item
{
    [Serializable]
    public class ItemInventory
    {
        public int itemId = UnityEngine.Random.Range(0, 1000);
        //public string itemName; them sau
        public ItemProfileSO itemProfile;
        public int itemCount;
    }
}
 