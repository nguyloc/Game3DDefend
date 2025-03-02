using _Data.Tower.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Data.SkillHotBar
{
    public class SunDiscSkill : MonoBehaviour
    {
        public TowerCode towerCode; 
        public Image slotImage; 
        public TMP_Text priceText; 
        public Color normalColor = Color.white;
        public Color notEnoughMoneyColor = Color.red;
        
        private TowerManager towerManager;
        private int towerPrice;
        
        
        void Start()
        {
            towerManager = TowerManager.Instance;
            towerPrice = towerManager.GetTowerPrice(towerCode);
        }

        void Update()
        {
            if (towerManager.CanAffordTower(towerCode))
            {
                slotImage.color = normalColor;
                priceText.color = normalColor;
            }
            else
            {
                slotImage.color = notEnoughMoneyColor;
                priceText.color = notEnoughMoneyColor;
            }
        }
    }
}
