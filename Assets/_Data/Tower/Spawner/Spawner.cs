using System.Collections.Generic;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public abstract class Spawner<T> : LocMonoBehaviour
    {
        //[SerializeField] protected int spawnCount = 0;
        [SerializeField] protected List<T> inPoolObjs;
        
        
        public virtual Transform Spawn(Transform prefab)
        {
            Transform newObject = Instantiate(prefab);
            return newObject;
        }
        
        public virtual void Despawn(Transform obj)
        {
            Destroy(obj.gameObject);
        }
        
        public virtual void Despawn(T obj)
        {
            if (obj is MonoBehaviour monoBehaviour)
            {
                monoBehaviour.gameObject.SetActive(false);
                this.AddObjectToPool(obj);
            }
        }
        
        protected virtual void AddObjectToPool(T obj)
        {
            this.inPoolObjs.Add(obj);
        }
    }
}
