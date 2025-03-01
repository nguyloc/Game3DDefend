using System;
using UnityEngine;
using Invector.vCharacterController;

namespace _Data.Scripts
{
    public class HideMouse : MonoBehaviour
    {
        public bool isUIOpen = false;
        private vThirdPersonInput playerInput; 

        [Obsolete("Obsolete")]
        void Start()
        {
            playerInput = FindObjectOfType<vThirdPersonInput>(); 
            HideCursor();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                ToggleUI();
            }
        }

        public void ToggleUI()
        {
            isUIOpen = !isUIOpen;

            if (isUIOpen)
            {
                ShowCursor();
                if (playerInput != null) playerInput.enabled = false; 
            }
            else
            {
                HideCursor();
                if (playerInput != null) playerInput.enabled = true; 
            }
        }

        public void ShowCursor()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public void HideCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
