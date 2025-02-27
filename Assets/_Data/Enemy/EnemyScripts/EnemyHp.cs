using _Data.UI.Slide;
using UnityEngine;

namespace _Data.Enemy.EnemyScripts
{
    public class EnemyHp : SliderHp
    {
        [SerializeField] protected EnemyController enemyController;
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEnemyController();
        }
        
        protected virtual void LoadEnemyController()
        {
            if (this.enemyController != null) return;
            this.enemyController = GetComponentInParent<EnemyController>();
            Debug.Log(transform.name + ": LoadEnemyController", gameObject);
        }
        
        protected override float GetValue()
        {
            return (float) this.enemyController.EnemyDamageReceiver.CurrentHP / (float) this.enemyController.EnemyDamageReceiver.MaxHP;
        }
    }
}
