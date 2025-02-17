using System;
using _Data.Inventory;
using _Data.Inventory.Item;
using _Data.Scripts;
using TMPro;
using UnityEngine;

namespace _Data.UI.TextElement
{
    public class GoldTextCount : LocMonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI textPro;

        protected void FixedUpdate()
        {
            this.LoadGoldCount();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTextPro();
        }
        
        protected virtual void LoadTextPro()
        {
            if (this.textPro != null) return;
            this.textPro = GetComponent<TextMeshProUGUI>();
            Debug.Log(transform.name + " TextMeshProUGUI loaded", gameObject);
        }
        
        protected virtual void LoadGoldCount()
        {
            ItemInventory item = InventoryManager.Instance.Monies().FindItem(ItemCode.Gold);
            string goldCount;    
            if (item == null) goldCount ="0";
            else goldCount = item.itemCount.ToString();
            this.textPro.text = goldCount;
        }
    }
}
