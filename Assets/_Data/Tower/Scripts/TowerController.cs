using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerController : LocMonoBehaviour
    {
        [SerializeField] protected Transform model;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadModel();
        }

        protected virtual void LoadModel()
        {
            if (this.model != null) return;
            this.model = transform.Find("Model");
            this.model.localPosition = new Vector3(0, 0, 0);
            Debug.Log(transform.name + " is loading Model", gameObject);
        }
    }
}

