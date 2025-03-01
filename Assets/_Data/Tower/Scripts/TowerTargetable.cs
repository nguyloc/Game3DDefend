using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    [RequireComponent(typeof(SphereCollider))]
    
    public class TowerTargetable : LocMonoBehaviour
    {
        [SerializeField] protected SphereCollider sphereCollider;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSphereCollider();
        }
        
        protected virtual void LoadSphereCollider()
        {
            if (this.sphereCollider != null) return;
            this.sphereCollider = GetComponent<SphereCollider>();
            this.sphereCollider.isTrigger = true;
            this.sphereCollider.radius = 0.2f;
            Debug.Log(transform.name + " is loading SphereCollider", gameObject);
        }
    }
}
