using _Data.Scripts;
using UnityEngine;

namespace _Data.UI.Slide
{
    public abstract class SliderAbstract : LocMonoBehaviour
    {
        [SerializeField] protected UnityEngine.UI.Slider slider;

        protected override void Start()
        {
            this.slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadSlider();
        }

        protected virtual void LoadSlider()
        {
            if (this.slider != null) return;
            this.slider = GetComponent<UnityEngine.UI.Slider>();
            Debug.Log(transform.name + ": LoadSlider", gameObject);
        }
        
        protected virtual void OnSliderValueChanged(float value)
        {
            //
        }
    }
}
