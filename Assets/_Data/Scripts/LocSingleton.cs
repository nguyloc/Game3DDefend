using UnityEngine;

namespace _Data.Scripts
{
    public abstract class LocSingleton<T> : LocMonoBehaviour where T : LocMonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null) Debug.LogError(typeof(T) + " is NULL");
                return _instance;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            this.LoadInstance();
        }

        // protected virtual void LoadInstance()
        // {
        //     if (_instance == null)
        //     {
        //         _instance = this as T;
        //         DontDestroyOnLoad(gameObject);
        //         return;
        //     }
        //
        //     if (_instance != this) Debug.LogError("Another instance of " + typeof(T) + " already exists");
        // }
        protected virtual void LoadInstance()
        {
            if (_instance == null)
            {
                _instance = this as T;
                if (transform.parent != null)
                {
                    transform.SetParent(null);
                }
                DontDestroyOnLoad(gameObject);
                return;
            }

            if (_instance != this) Debug.LogError("Another instance of " + typeof(T) + " already exists");
        }
    }
}
