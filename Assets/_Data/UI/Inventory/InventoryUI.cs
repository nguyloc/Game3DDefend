using _Data.Scripts;

namespace _Data.UI.Inventory
{
    public class InventoryUI : LocMonoBehaviour
    {
        protected bool isShow = true;
        bool IsShow => isShow;
        
        protected override void Start()
        {
            base.Start();
            this.Hide();
        }
        
        public virtual void Show()
        {
            this.gameObject.SetActive(true);
            this.isShow = true;
        }
        
        public virtual void Hide()
        {
            this.gameObject.SetActive(false);
            this.isShow = false;
        }
    }
}
