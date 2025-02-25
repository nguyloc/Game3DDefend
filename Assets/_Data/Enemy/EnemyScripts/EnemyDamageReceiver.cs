using _Data.DamageSystem;
using _Data.Inventory;
using _Data.Inventory.Item;
using _Data.Inventory.ItemDrop;
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
            this.RewardOnDead();
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
        
        protected virtual void RewardOnDead()
        {
            ItemsDropManager.Instance.DropMany(ItemCode.Gold, 10, transform.position);
            ItemsDropManager.Instance.DropMany(ItemCode.PlayerExp, 10, transform.position);
            ItemsDropManager.Instance.DropMany(ItemCode.Wand, 1, transform.position);
        }
    }
}
