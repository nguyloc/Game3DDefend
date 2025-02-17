using _Data.Scripts;
using _Data.UI.Inventory;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.UI.Buttons
{
    public class ButtonInventoryToggle : ButtonAbstract
    {
        protected override void OnClick()
        {
            InventoryUI.Instance.Toggle();
        }
    }
}
