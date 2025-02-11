using _Data.Scripts;
using UnityEngine;

namespace _Data.Player.Scripts
{
    public abstract class PlayerAbstract : LocMonoBehaviour
    {
        [SerializeField] protected PlayerController playerController;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPlayerController();
        }
        
        protected virtual void LoadPlayerController()
        {
            if (this.playerController != null) return;
            this.playerController = transform.GetComponentInParent<PlayerController>();
            Debug.Log(transform.name + " : LoadPlayerController", gameObject);
        }
    }
}
