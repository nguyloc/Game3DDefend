using System;
using _Data.Player.Scripts;
using UnityEngine;

namespace _Data.UI.TextElement
{
    public class TextPlayerLevelCount : TextAbstract
    {
        protected void FixedUpdate()
        {
            this.LoadCount();
        }
        
        protected virtual void LoadCount()
        {
            this.textPro.text = PlayerController.Instance.Level.CurrentLevel.ToString();
        }
    }
}
