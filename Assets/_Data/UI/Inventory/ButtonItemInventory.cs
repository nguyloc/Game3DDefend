using System;
using _Data.Inventory.Item;
using _Data.UI.Buttons;
using TMPro;
using UnityEngine;

namespace _Data.UI.Inventory
{
    public class ButtonItemInventory : ButtonAbstract
    {
        [SerializeField] protected TextMeshProUGUI textItemName;
        [SerializeField] protected TextMeshProUGUI textItemCount;
        
        [SerializeField] protected ItemInventory itemInventory;
        public ItemInventory ItemInventory => itemInventory;

        protected bool IsDestroyed = false;
        

        protected void FixedUpdate()
        {
            this.ItemsUpdating();
        }


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTextItemName();
            this.LoadTextItemCount();
        }
        
        public virtual void SetItem(ItemInventory itemInventory)
        {
            this.itemInventory = itemInventory;
        }
        
        protected override void OnClick()
        {
            Debug.Log("Clicked ButtonItemInventory: " + this.itemInventory.itemProfile.itemName);
        }
        
        protected virtual void LoadTextItemName()
        {
            if (this.textItemName != null) return;
            this.textItemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            Debug.Log(transform.name + " has no TextItemName component.", gameObject);
        }
        
        protected virtual void LoadTextItemCount()
        {
            if (this.textItemCount != null) return;
            this.textItemCount = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
            Debug.Log(transform.name + " has no TextItemCount component.", gameObject);
        }
        
        protected virtual void ItemsUpdating()
        {
            if (IsDestroyed) return;
            
            this.textItemName.text = this.itemInventory.itemName;
            this.textItemCount.text = this.itemInventory.itemCount.ToString();
            
            if (this.itemInventory.itemCount == 0 )
            {
                IsDestroyed = true;
                Destroy(gameObject);
            }
        }
    }
}
