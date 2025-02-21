using _Data.UI.Slide;

namespace _Data.UI.Slider
{
    public abstract class SliderHp : SliderAbstract
    {
        protected void FixedUpdate()
        {
            this.UpdateSlider();
        }

        protected virtual void UpdateSlider()
        {
            this.slider.value = this.GetValue();
        }

        protected abstract float GetValue();
    }
}
