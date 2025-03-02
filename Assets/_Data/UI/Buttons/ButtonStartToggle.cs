using _Data.Sound;
using _Data.UI.Menu;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Data.UI.Buttons
{
    public class ButtonStartToggle : ButtonAbstract
    {
        public virtual void StartGame()
        {
            MenuUI.Instance.Hide();
        }
        
        protected override void OnClick()
        {
            this.StartGame();
        }
    }
}
