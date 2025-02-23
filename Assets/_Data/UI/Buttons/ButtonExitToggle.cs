using _Data.Sound;
using _Data.Scripts;
using UnityEngine;


namespace _Data.UI.Buttons
{
    public class ButtonExitToggle : ButtonAbstract
    {
        protected override void OnClick()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }
}
