using System.Collections.Generic;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public abstract class Spawner<T> : LocMonoBehaviour where T : PoolObj
    {
        [SerializeField] protected int spawnCount = 0;
        [SerializeField] protected List<T> inPoolObjs;
        
        public virtual Transform Spawn(Transform prefab)
        {
            Transform newObject = Instantiate(prefab);
            return newObject;
        }
        
        public virtual T Spawn(T prefab)
        {
            T newObject = this.GetObjFromPool(prefab);
            if (newObject == null)
            {
                newObject = Instantiate(prefab);
                spawnCount++;
                this.UpdateName(prefab.transform, newObject.transform);
            }
            return newObject;
        }
        
        public virtual T Spawn(T buletPrefab, Vector3 position)
        { 
            T newBullet = this.Spawn(buletPrefab); 
            newBullet.transform.position = position; 
            return newBullet;
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
        
        protected virtual void RemoveObjectFromPool(T obj)
        {
            this.inPoolObjs.Remove(obj);
        }
        
        protected virtual void UpdateName(Transform prefab, Transform newObject)
        {
            newObject.name = prefab.name + "_" + this.spawnCount;
        }
        
        protected virtual T GetObjFromPool(T prefab)
        {
            foreach (T inPoolObj in this.inPoolObjs)
            {
                if (prefab.GetName() == inPoolObj.GetName())
                {
                    this.RemoveObjectFromPool(inPoolObj);
                    return inPoolObj;
                }
            }
            return null;
        }
    }
}
