using System.Collections.Generic;
using _Data.Inventory.Item;
using _Data.Scripts;
using com.cyborgAssets.inspectorButtonPro;
using UnityEngine;


namespace _Data.Inventory
{
    public class InventoryTester : LocMonoBehaviour
    {
        [ProButton]
        public virtual void AddTestItems (ItemCode itemCode, int count)
        {
            InventoryController items = InventoryManager.Instance.GetByCodeName(InventoryCodeName.Items);
            for (int i = 0; i < count; i++)
            {
                ItemInventory wand = new ItemInventory();
                wand.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
                wand.itemCount = 1;
                wand.itemName = wand.itemProfile.itemName;
                items.AddItem(wand);
            }
        }

        [ProButton]
        public virtual void AddTestGolds (ItemCode itemCode, int count)
        {
            InventoryController inventoryController = InventoryManager.Instance.GetByCodeName(InventoryCodeName.Monies);

            ItemInventory gold = new ItemInventory();
            gold.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            gold.itemCount = count;
            gold.itemName = gold.itemProfile.itemName;
            inventoryController.AddItem(gold);
        }
        
        [ProButton]
        public virtual void RemoveTestItems (ItemCode itemCode, int count)
        {
            InventoryController items = InventoryManager.Instance.GetByCodeName(InventoryCodeName.Items);
            for (int i = 0; i < count; i++)
            {
                ItemInventory wand = new ItemInventory();
                wand.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
                wand.itemCount = 1;
                wand.itemName = wand.itemProfile.itemName;
                items.RemoveItem(wand);
            }
        }
        
        [ProButton]
        public virtual void RemoveTestGolds (ItemCode itemCode, int count)
        {
            InventoryController inventoryController = InventoryManager.Instance.GetByCodeName(InventoryCodeName.Monies);

            ItemInventory gold = new ItemInventory();
            gold.itemProfile = InventoryManager.Instance.GetProfileByCode(itemCode);
            gold.itemCount = count;
            gold.itemName = gold.itemProfile.itemName;
            inventoryController.RemoveItem(gold);
        }
    }
}
