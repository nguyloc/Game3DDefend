using _Data.Level;
using _Data.Player.Scripts;
using UnityEngine;

namespace _Data.UI.Slide
{
    public class SliderPlayerExp : SliderAbstract
    {
        [SerializeField] private PlayerLevel playerLevel;
        

        protected void LateUpdate()
        {
            this.LoadExp();
        }
        
        protected virtual void LoadExp()
        {
            if (playerLevel == null) return;

            int currentExp = playerLevel.CurrentExp;
            int nextExp = playerLevel.NextLevelExp;

            float targetValue = (float)currentExp / nextExp;
            this.OnSliderValueChanged(targetValue); // Gọi hàm cập nhật slider
        }
    }
}
