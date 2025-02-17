using _Data.Inventory.Item;
using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryItems : InventoryController
    {
        public override InventoryCodeName GetName()
        {
            return InventoryCodeName.Items;
        }
    }
}
