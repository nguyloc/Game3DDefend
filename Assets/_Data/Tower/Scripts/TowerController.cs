using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerController : LocMonoBehaviour
    {
        [SerializeField] protected Transform model;
        [SerializeField] protected Transform rotator;

        public Transform Rotator => rotator;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadModel();
        }

        protected virtual void LoadModel()
        {
            if (this.model != null) return;
            this.model = transform.Find("Model");
            this.rotator = this.model.Find("Rotator");
            Debug.Log(transform.name + " is loading Model", gameObject);
        }
    }
}

