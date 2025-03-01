using _Data.Scripts;
using TMPro;
using UnityEngine;

namespace _Data.UI.TextElement
{
    public class Text3DAbstract : LocMonoBehaviour
    {
        [SerializeField] protected TextMeshPro textPro;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadTextPro();
        }

        protected virtual void LoadTextPro()
        {
            if (this.textPro != null) return;
            this.textPro = GetComponent<TextMeshPro>();
            Debug.Log(transform.name + ": LoadTextPro", gameObject);
        }
    }
}
