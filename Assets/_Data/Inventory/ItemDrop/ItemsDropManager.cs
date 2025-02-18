using _Data.Inventory.Item;
using _Data.Scripts;
using UnityEngine;

namespace _Data.Inventory.ItemDrop
{
    public class ItemsDropManager : LocSingleton<ItemsDropManager>
    {
        [SerializeField] protected ItemsDropSpawner spawner;
        public ItemsDropSpawner Spawner => spawner;
        
        protected float spawnHeight = 1f;
        protected float forceAmount = 5f;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSpawner();
        }
        
        protected virtual void LoadSpawner()
        {
            if (this.spawner != null) return;
            this.spawner = GetComponent<ItemsDropSpawner>();
            Debug.Log (transform.name + " : LoadSpawner : " , gameObject);
        }

        public virtual void DropMany(ItemCode itemCode, int dropCount, Vector3 dropPosition)
        {
            for (int i = 0; i < dropCount; i++)
            {
                this.Drop(itemCode, 1, dropPosition);
            }
        }
        
        public virtual void Drop(ItemCode itemCode, int dropCount, Vector3 dropPosition)
        {
            Vector3 spawnPosition = dropPosition + new Vector3(Random.Range(-0.5f, 0.5f), spawnHeight, Random.Range(-0.5f, 0.5f));
            ItemDropController itemPrefab = this.spawner.PoolPrefabs.GetByName(itemCode.ToString());
            
            if(itemPrefab == null) itemPrefab = this.spawner.PoolPrefabs.GetByName("DefaultDrop");

            ItemDropController newItem = this.spawner.Spawn(itemPrefab, spawnPosition);
            newItem.SetValue(itemCode, dropCount);

            newItem.gameObject.SetActive(true);

            Vector3 randomDirection = Random.onUnitSphere;
            randomDirection.y = Mathf.Abs(randomDirection.y);
            newItem.Rb.AddForce(randomDirection * forceAmount, ForceMode.Impulse);
        }
    }
}
