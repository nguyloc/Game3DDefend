using _Data.Inventory.Item;
using UnityEngine;

namespace _Data.Inventory
{
    public class InventoryCurrency : InventoryController
    {
        public override InventoryCodeName GetName()
        {
            return InventoryCodeName.Currency;
        }
    }
}
