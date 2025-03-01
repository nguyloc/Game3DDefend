using _Data.Sound;
using _Data.Scripts;


namespace _Data.UI.Buttons
{
    public class ButtonMusicToggle : ButtonAbstract
    {
        protected virtual void LateUpdate()
        {
            this.HotkeyToogleMusic();
        }

        protected override void OnClick()
        {
            SoundManager.Instance.ToggleMusic();
        }

        protected virtual void HotkeyToogleMusic()
        {
            if (InputHotKey.Instance.isToogleMusic) SoundManager.Instance.ToggleMusic();
        }
    }
}
