using _Data.Inventory.Item;
using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryMonies : InventoryController
    {
        public override InventoryCodeName GetName()
        {
            return InventoryCodeName.Monies;
        }
    }
}
