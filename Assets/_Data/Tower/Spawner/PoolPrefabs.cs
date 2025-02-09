using System.Collections.Generic;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public class PoolPrefabs<T> : LocMonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] protected List<T> prefabs = new();
        

        protected override void Awake()
        {
            base.Awake();
            this.HidePrefabs();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPrefabs();
        }
        
        protected virtual void LoadPrefabs()
        {
            if (this.prefabs.Count > 0) return;
            foreach (Transform child in transform)
            {
                T classPrefab = child.GetComponent<T>();
                if (classPrefab) this.prefabs.Add(classPrefab);
            }
            Debug.Log(transform.name + " : LoadPrefabs", gameObject);
        }
        
        protected virtual void HidePrefabs()
        {
            foreach (T prefab in this.prefabs)
            {
                prefab.gameObject.SetActive(false);
            }
        }
        
        public virtual T GetRandom()
        {
            int rand = Random.Range(0, this.prefabs.Count);
            return this.prefabs[rand];
        }
        
        public virtual T GetByName(string prefabName)
        {
            foreach (T prefab in this.prefabs)
            {
                if (prefab.name != prefabName) continue;
                return prefab;
            }
            return null;
        }
    }
}
