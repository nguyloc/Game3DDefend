using _Data.Sound;

namespace _Data.UI.Slide
{
    public class SliderVolumeMusic : SliderAbstract
    {
        protected override void OnSliderValueChanged(float value)
        {
            SoundManager.Instance.VolumeMusicUpdating(value);
        }
    }
}
