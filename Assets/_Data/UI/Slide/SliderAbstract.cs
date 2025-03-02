using System.Collections;
using _Data.Scripts;
using UnityEngine;

namespace _Data.UI.Slide
{
    public abstract class SliderAbstract : LocMonoBehaviour
    {
        [SerializeField] protected UnityEngine.UI.Slider slider;
        [SerializeField] protected float smoothTime = 0.2f;
        
        protected Coroutine currentCoroutine;

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
        
        protected virtual void OnSliderValueChanged(float targetValue)
        {
            if (currentCoroutine != null)
                StopCoroutine(currentCoroutine);

            currentCoroutine = StartCoroutine(SmoothTransition(targetValue));
        }
        
        private IEnumerator SmoothTransition(float targetValue)
        {
            float elapsedTime = 0f;
            float startValue = slider.value;

            while (elapsedTime < smoothTime)
            {
                elapsedTime += Time.deltaTime;
                slider.value = Mathf.Lerp(startValue, targetValue, elapsedTime / smoothTime);
                yield return null;
            }

            slider.value = targetValue;
        }
    }
}
