using System.Runtime.InteropServices;
using _Data.Tower.Scripts;
using _Data.UI.TextElement;
using UnityEngine;

namespace _Data.Level.UILevelText
{
    public abstract class TextLevel : Text3DAbstract
    {
 
        protected virtual void FixedUpdate()
        {
            this.UpdateLevel();
        }

        protected virtual void UpdateLevel()
        {
            this.textPro.text = this.GetLevel();
        }

        protected abstract string GetLevel();
    }
}

