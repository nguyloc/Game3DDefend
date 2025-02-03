using System.Collections.Generic;
using UnityEngine;
using _Data.Scripts;

namespace _Data.Paths
{
    public class Path : LocMonoBehaviour
    {
        [SerializeField] protected List<Point> points;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPoints();
        }
        
        protected virtual void LoadPoints()
        {
            if (this.points.Count > 0) return;
            foreach (Transform child in transform)
            {
                var point = child.GetComponent<Point>();
                point.LoadNextPoint();
                this.points.Add(point);
            }
            
            Debug.Log(transform.name + "Load Points", gameObject);
        }
        
        public Point GetPoint(int index)
        {
            if (index < 0 || index >= this.points.Count)
            {
                return null;
            }
            return this.points[index];
        }
    }
}
