using _Data.Inventory;
using _Data.Inventory.Item;
using UnityEngine;

namespace _Data.Level
{
    public abstract class LevelByItem : LevelAbstract
    {
        [SerializeField] protected ItemInventory playerExp;

        protected override int GetCurrentExp()
        {
            if (this.GetPlayerExp() == null) return 0;
            return this.GetPlayerExp().itemCount;
        }

        protected override bool DeductExp(int exp)
        {
            return this.GetPlayerExp().Deduct(exp);
        }

        protected virtual ItemInventory GetPlayerExp()
        {
            if(this.playerExp == null || this.playerExp.ItemID == 0) this.playerExp = InventoriesManager.Instance.Currency().FindItem(ItemCode.PlayerExp);
            return this.playerExp;
        }
    }
}
