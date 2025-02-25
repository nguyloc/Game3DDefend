using _Data.Sound;
using _Data.Scripts;
using UnityEngine;


namespace _Data.UI.Buttons
{
    public class ButtonExitToggle : ButtonAbstract
    {
        protected override void OnClick()
        {
            Debug.Log("Thoát game!"); // Kiểm tra xem hàm có được gọi không

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Dừng Play Mode trong Editor
#else
        Application.Quit(); // Thoát game khi build
#endif
        }
    }
}