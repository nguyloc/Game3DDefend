using UnityEngine;

namespace _Data.Scripts
{
    public class InputManager : LocSingleton<InputManager>
    {
        protected bool isAttackLight = false;
        protected bool isAiming = false;
        
        private void Update()
        {
            this.CheckAiming();
            this.CheckAttackLight();
        }

        protected virtual void CheckAiming()
        {
            this.isAiming = Input.GetMouseButton(1);
        } 
        
        protected virtual void CheckAttackLight()
        {
            this.isAttackLight = Input.GetMouseButtonUp(0);
        } 
        
        
        public virtual bool IsAiming()
        {
            return this.isAiming;
        }
        
        public virtual bool IsAttackLight()
        {
            return this.isAttackLight;
        }
    }
}
