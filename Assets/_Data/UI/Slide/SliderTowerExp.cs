using _Data.Level;
using _Data.Player.Scripts;
using UnityEngine;

namespace _Data.UI.Slide
{
    public class SliderTowerExp : SliderAbstract
    {
        [SerializeField] private TowerLevel _towerLevel;
        
        protected virtual void LateUpdate()
        {
            this.LoadExp();
        }
        
        protected virtual void LoadExp()
        {
            if (_towerLevel == null) return;

            int currentExp = _towerLevel.CurrentExp;
            int nextExp = _towerLevel.NextLevelExp;

            float targetValue = (float)currentExp / nextExp;
            this.OnSliderValueChanged(targetValue); // Gọi hàm cập nhật slider
        }
    }
}
