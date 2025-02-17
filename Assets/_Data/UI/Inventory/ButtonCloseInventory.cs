using _Data.UI.Buttons;

namespace _Data.UI.Inventory
{
    public class ButtonCloseInventory : ButtonAbstract
    {
        public virtual void CloseInventoryUI()
        {
            InventoryUI.Instance.Hide();
        }
        
        protected override void OnClick()
        {
            this.CloseInventoryUI();
        }
    }
}
