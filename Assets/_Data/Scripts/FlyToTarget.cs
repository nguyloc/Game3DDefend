using System;
using UnityEngine;

namespace _Data.Scripts
{
    public class FlyToTarget : LocMonoBehaviour
    {
        protected Transform target;
        protected float speed = 30f;

        protected void Update()
        {
            this.Flying();
        }
        
        public virtual void SetTarget(Transform target)
        {
            this.target = target;
            transform.parent.LookAt(target);
        }
        
        protected virtual void Flying()
        {
            if (this.target == null) return;
            transform.parent.Translate(speed * Time.deltaTime * Vector3.forward);
        }
    }
}
