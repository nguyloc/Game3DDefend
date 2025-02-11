using UnityEngine;

namespace _Data.Scripts
{
    public class InputManager : LocSingleton<InputManager>
    {
        protected bool isLeftClick = false;
        protected bool isRightClick = false;
        
        private void Update()
        {
            this.CheckRightClick();
            this.CheckLeftClick();
        }

        protected virtual void CheckRightClick()
        {
            this.isRightClick = Input.GetMouseButton(1);
        } 
        
        protected virtual void CheckLeftClick()
        {
            this.isLeftClick = Input.GetMouseButton(0);
        }
        
        public virtual bool IsRightClick()
        {
            return this.isRightClick;
        }
        
        public virtual bool IsLeftClick()
        {
            return this.isLeftClick;
        }
    }
}
