using _Data.Scripts;
using UnityEngine;

namespace _Data.Paths
{
    public class Point : LocMonoBehaviour
    {
        [SerializeField] protected Point nextPoint;
        
        public Point NextPoint => nextPoint;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadNextPoint();
        }

        public virtual void LoadNextPoint()
        {
            if (this.nextPoint != null) return;
            var siblingIndex = transform.GetSiblingIndex();
            if (siblingIndex + 1 < transform.parent.childCount)
            {
                this.nextPoint = transform.parent.GetChild(siblingIndex + 1).GetComponent<Point>();
            }
            
            //Debug.Log(transform.name + "Load Next Point", gameObject);
        }
    }
}
