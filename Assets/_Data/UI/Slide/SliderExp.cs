using System;
using _Data.Level;
using _Data.Player.Scripts;
using UnityEngine;

namespace _Data.UI.Slide
{
    public class SliderExp : SliderAbstract
    {
        protected void LateUpdate()
        {
            this.LoadExp();
        }
        
        protected virtual void LoadExp()
        {
            //int currentExp;
            //int nextExp;

            //layerLevel level = Player;
        }
    }
}
