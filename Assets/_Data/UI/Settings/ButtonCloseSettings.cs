using _Data.UI.Buttons;
using _Data.UI.Inventory;

namespace _Data.UI.Settings
{
    public class ButtonCloseSettings : ButtonAbstract
    {
        public virtual void CloseSettingsUI()
        {
            SettingsUI.Instance.Hide();
        }
        
        protected override void OnClick()
        {
            this.CloseSettingsUI();
        }
    }
}
