using _Data.Scripts;
using UnityEngine;

namespace _Data.UI.Settings
{
    public class SettingsUI : LocSingleton<SettingsUI>
    {
        protected bool isShow = true;
        protected bool IsShow => isShow;

        [SerializeField]
        protected Transform showHide;
        

        protected override void Start()
        {
            base.Start();
            this.Hide();
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadShowHide();
        }

        
        protected virtual void LoadShowHide()
        {
            if (this.showHide != null) return;
            this.showHide = transform.Find("ShowHide");
            Debug.Log(transform.name + " has no ShowHide component.", gameObject);
        }

        public virtual void Show()
        {
            this.showHide.gameObject.SetActive(true);
            this.isShow = true;
        }

        public virtual void Hide()
        {
            this.showHide.gameObject.SetActive(false);
            this.isShow = false;
        }

        public virtual void Toggle()
        {
            if (this.isShow) this.Hide();
            else this.Show();
        }
    }
}
