using _Data.Sound;
using _Data.Scripts;
using _Data.UI.Settings;


namespace _Data.UI.Buttons
{
    public class ButtonSettingsToggle : ButtonAbstract
    {
        protected virtual void LateUpdate()
        {
            this.HotkeyToogleSettings();
        }

        protected override void OnClick()
        {
            SettingsUI.Instance.Toggle();
        }

        protected virtual void HotkeyToogleSettings()
        {
           if (InputHotKey.Instance.isToogleSetting) SettingsUI.Instance.Toggle();
        }
    }
}
