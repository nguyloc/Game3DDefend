using System;
using _Data.Inventory;
using _Data.Inventory.Item;
using _Data.Scripts;
using TMPro;
using UnityEngine;

namespace _Data.UI.TextElement
{
    public abstract class TextAbstract : LocMonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI textPro;
        

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
    }
}
