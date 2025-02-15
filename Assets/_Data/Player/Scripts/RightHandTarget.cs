using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Scripts
{
    public class RightHandTarget : LocMonoBehaviour
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            transform.localPosition = new Vector3(-0.368f, 0.315f, 0.315f);
            transform.localRotation = Quaternion.Euler(-183.774f, -107.322f, -6.533997f);
        }
    }
}
