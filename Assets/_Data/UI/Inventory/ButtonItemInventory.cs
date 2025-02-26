using System;
using _Data.Inventory.Item;
using _Data.UI.Buttons;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.UI.Inventory
{
    public class ButtonItemInventory : ButtonAbstract
    {
        [SerializeField] protected TextMeshProUGUI textItemName;
        [SerializeField] protected TextMeshProUGUI textItemCount;
        [SerializeField] protected Image spriteItem;
        
        [SerializeField] protected ItemInventory itemInventory;
        public ItemInventory ItemInventory => itemInventory;
        

        protected void FixedUpdate()
        {
            this.ItemsUpdating();
        }


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTextItemName();
            this.LoadTextItemCount();
            this.LoadSpriteItem();
        }
        
        public virtual void SetItem(ItemInventory itemInventory)
        {
            this.itemInventory = itemInventory;
        }
        
        protected override void OnClick()
        {
            Debug.Log("Clicked ButtonItemInventory: " + this.itemInventory.ItemProfile.itemName);
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
        
        protected virtual void LoadSpriteItem()
        {
            if (this.spriteItem != null) return;
            this.spriteItem = transform.Find("ItemSprite").GetComponent<Image>();
            Debug.Log(transform.name + " has no SpriteItem component.", gameObject);
        }
        
        protected virtual void ItemsUpdating()
        {
            this.textItemName.text = this.itemInventory.GetItemName();
            this.textItemCount.text = this.itemInventory.itemCount.ToString();

            if (this.itemInventory.itemCount == 0) Destroy(gameObject);
        }
    }
}
