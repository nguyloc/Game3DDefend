using UnityEngine;

namespace _Data.Scripts
{
    public class LocMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            this.LoadComponents();
        }

        protected void Reset()
        {
            this.LoadComponents();
        }

        protected virtual void LoadComponents()
        {
            // Load all components here
        }
    }
}

