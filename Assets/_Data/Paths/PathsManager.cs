using System.Collections.Generic;
using UnityEngine;
using _Data.Scripts;

namespace _Data.Paths
{
    public class PathsManager : LocSingleton<PathsManager>
    {
        [SerializeField] protected List<Path> paths = new();
        
        protected override void Awake()
        {
            base.Awake();
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPaths();
        }
        
        protected virtual void LoadPaths()
        {
           if (this.paths.Count > 0) return;
           foreach (Transform child in transform)
           {
               var path = child.GetComponent<Path>();
               this.paths.Add(path);
           }
           
           Debug.Log(transform.name + "Load Paths", gameObject);
        }
        
        public Path GetPath(string pathName)
        {
            foreach (var path in this.paths)
            {
                if (path.name == pathName)
                {
                    return path;
                }
            }
            return null;
        }
    }
}