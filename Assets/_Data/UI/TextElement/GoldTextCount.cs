using _Data.Inventory;
using _Data.Inventory.Item;

namespace _Data.UI.TextElement
{
    public class GoldTextCount : TextAbstract
    {
        protected void FixedUpdate()
        {
            this.LoadGoldCount();
        }
        
        protected virtual void LoadGoldCount()
        {
            ItemInventory item = InventoriesManager.Instance.Currency().FindItem(ItemCode.Gold);
            string goldCount;    
            if (item == null) goldCount ="0";
            else goldCount = item.itemCount.ToString();
            this.textPro.text = goldCount;
        }
    }
}
