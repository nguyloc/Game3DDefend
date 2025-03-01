using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Scripts
{
    public class RightHandHint : LocMonoBehaviour
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            transform.localPosition = new Vector3(-0.143f, 0.358f, 0.033f);
            transform.localRotation = Quaternion.Euler(0f, -180f, -90f);
        }
    }
}
