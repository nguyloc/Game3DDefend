using UnityEngine;

namespace _Data.Weapon
{
    public class WandController : WeaponAbtract
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            transform.localPosition = new Vector3(-0.03100017f, 0.08800076f, 0.09199967f);
            transform.localRotation = Quaternion.Euler(201.612f, 27.289f, -61.99402f);
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
