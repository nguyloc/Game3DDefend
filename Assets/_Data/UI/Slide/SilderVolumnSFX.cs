using _Data.Sound;

namespace _Data.UI.Slide
{
    public class SliderVolumeSfx : SliderAbstract
    {
        protected override void OnSliderValueChanged(float value)
        {
            SoundManager.Instance.VolumeSfxUpdating(value);
        }
    }
}
