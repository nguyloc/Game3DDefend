using _Data.Scripts;
using UnityEngine;

namespace _Data.DamageSystem.Bullet
{
    public class BulletController : LocMonoBehaviour
    {
        [SerializeField]
        protected Bullet bullet;

        public Bullet Bullet => bullet;

        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadBullet();
        }

        protected virtual void LoadBullet()
        {
            if (this.bullet != null) return;
            this.bullet = GetComponent<Bullet>();
            Debug.Log(transform.name + " Bullet loaded", gameObject);
        }
    }
}
