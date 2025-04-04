using UnityEngine;

namespace _Data.Scripts
{
    public class LocMonoBehaviour : MonoBehaviour
    {
        protected virtual void Start()
        {
            
        }
        
        protected virtual void Awake()
        {
            this.LoadComponents();
        }

        protected virtual void Reset()
        {
            this.LoadComponents();
            this.ResetValue();
        }

        protected virtual void LoadComponents()
        {
            // Load all components here
        }
        
        protected virtual void ResetValue()
        {
            // Load all components here
        }

        public virtual void SetActive(bool status)
        {
            gameObject.SetActive(status);
        }
    }
}

