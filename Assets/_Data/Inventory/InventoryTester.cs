using System.Collections.Generic;
using _Data.Inventory.Item;
using _Data.Scripts;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;


namespace _Data.Inventory
{
    public class InventoryTester : LocMonoBehaviour
    {
        protected override void Start()
        {
            base.Start();
            this.AddTestItems(ItemCode.Gold, 1000);
        }

        [ProButton]
        public virtual void AddTestItems(ItemCode itemCode, int count)
        {
            for (int i = 0; i < count; i++)
            {
                InventoriesManager.Instance.AddItem(itemCode, 1);
            }
        }

        [ProButton]
        public virtual void RemoveTestItems(ItemCode itemCode, int count)
        {
            for (int i = 0; i < count; i++)
            {
                InventoriesManager.Instance.RemoveItem(itemCode, 1);
            }
        }
        
    }
}
