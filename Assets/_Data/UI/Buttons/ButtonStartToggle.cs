using _Data.Sound;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Data.UI.Buttons
{
    public class ButtonStartToggle : ButtonAbstract
    {
        protected override void OnClick()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
