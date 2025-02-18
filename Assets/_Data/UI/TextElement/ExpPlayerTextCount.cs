using _Data.Inventory;
using _Data.Inventory.Item;
using UnityEngine;

namespace _Data.UI.TextElement
{
    public class ExpPlayerTextCount : TextAbstract
    {
        protected void FixedUpdate()
        {
            this.LoadCount();
        }
        
        protected virtual void LoadCount()
        {
            ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.PlayerExp);
            string count;    
            if (item == null) count = "0";
            else count = item.itemCount.ToString();
            this.textPro.text = count;
        }
    }
}
