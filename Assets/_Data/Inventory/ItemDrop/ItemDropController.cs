using _Data.Inventory.Item;
using _Data.Spawner;
using UnityEngine;

namespace _Data.Inventory.ItemDrop
{
    [RequireComponent(typeof(Rigidbody))]
    public class ItemDropController : PoolObj
    {
        [SerializeField] protected Rigidbody rb;
        public Rigidbody Rb => rb;

        protected InventoryCodeName inventoryCodeName = InventoryCodeName.Items;
        public InventoryCodeName InventoryCodeName => inventoryCodeName;
        
        protected ItemCode itemCode;
        public ItemCode ItemCode => itemCode;
        
        protected int itemCount = 1;
        public int ItemCount => itemCount;
        
        public override string GetName()
        {
            return "ItemDrop";
        }
        
        public virtual void SetValue (ItemCode itemCode, int itemCount)
        {
            this.itemCode = itemCode;
            this.itemCount = itemCount;
        }
        
        // public virtual void SetValue (ItemCode itemCode, int itemCount, InventoryCodeName inventoryCodeName)
        // {
        //     this.itemCode = itemCode;
        //     this.itemCount = itemCount;
        //     this.inventoryCodeName = inventoryCodeName;
        // }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadRigidbody();
        }
        
        protected virtual void LoadRigidbody()
        {
            if (this.rb != null) return;
            this.rb = GetComponent<Rigidbody>();
            Debug.Log(transform.name + ": LoadRigidbody", gameObject);
        }
    }
}
