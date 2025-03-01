using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Skills
{
    public class AttackPoint : LocMonoBehaviour
    {
        protected override void Reset()
        {
            base.Reset();
            transform.localPosition = new Vector3(0.093f, 0.504f, 0.025f);
        }
    }
}
