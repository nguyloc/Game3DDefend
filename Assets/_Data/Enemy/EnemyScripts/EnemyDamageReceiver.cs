using _Data.DamageSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace _Data.Enemy.EnemyScripts
{
    [RequireComponent(typeof(CapsuleCollider))]
    public class EnemyDamageReceiver : DamageReceiver
    {
        [SerializeField]
        protected EnemyController enemyController;

        [SerializeField]
        protected CapsuleCollider capsuleCollider;

        // public EnemyController EnemyController => enemyController;


        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadCapsuleCollider();
            this.LoadEnemyController();
        }

        protected virtual void LoadCapsuleCollider()
        {
            if (this.capsuleCollider != null) return;
            this.capsuleCollider = GetComponent<CapsuleCollider>();
            this.capsuleCollider.isTrigger = true;
            this.capsuleCollider.radius = 0.5f;
            this.capsuleCollider.height = 1.5f;
            this.capsuleCollider.center = new Vector3(0, 1f, 0);
            Debug.Log(transform.name + " CapsuleCollider loaded", gameObject);
        }

        protected virtual void LoadEnemyController()
        {
            if (this.enemyController != null) return;
            this.enemyController = transform.parent.GetComponent<EnemyController>();
            Debug.Log(transform.name + " EnemyController loaded", gameObject);
        }

        protected override void OnDead()
        {
            base.OnDead();
            this.enemyController.Animator.SetBool("isDead", this.isDead);
            this.capsuleCollider.enabled = false;
            Invoke(nameof(this.Dissappear), 3f);
        }

        protected override void OnHurt()
        {
            base.OnHurt();
            this.enemyController.Animator.SetTrigger("isHurt");
        }

        protected virtual void Dissappear()
        {
            this.enemyController.Despawn.DoDespawn();
        }

        protected override void OnReborn()
        {
            base.OnReborn();
            this.capsuleCollider.enabled = true;
        }
    }
}
