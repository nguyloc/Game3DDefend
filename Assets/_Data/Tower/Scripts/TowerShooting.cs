using _Data.Effect;
using _Data.Effect.Fly;
using _Data.Enemy.EnemyScripts;
using _Data.Sound;
using _Data.Sound.SFX;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class TowerShooting : TowerAbstract
    {
        [SerializeField] protected bool isDisable = true;
        [SerializeField] protected float currentFirePoint = 0;
        [SerializeField] protected float targetLoadSpeed = 1f;
        [SerializeField] protected float shootingSpeed = 1f;
        [SerializeField] protected float rotationSpeed = 4f;
        [SerializeField] protected EnemyController target;
        
        
        [SerializeField] protected int killCount = 0;
        [SerializeField] protected int totalKill = 0;
        public int KillCount => killCount;
        
        
        [SerializeField] protected EffectSpawner effectSpawner;
        [SerializeField] protected SoundName shootSfxName = SoundName.Laser01;
        
        
       



        protected override void Start()
        {
            base.Start();
            Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
            Invoke(nameof(this.Shooting), this.shootingSpeed);
        }

        protected void FixedUpdate()
        {
            this.Looking();
            this.IsTargetDead();
        }
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadEffectSpawner();
        }
        
        protected virtual void LoadEffectSpawner()
        {
            if (this.effectSpawner != null) return;
            this.effectSpawner = GameObject.Find("EffectSpawner").GetComponent<EffectSpawner>();
            Debug.Log(transform.name + ": LoadEffectSpawner", gameObject);
        }
    
        protected virtual void TargetLoading()
        {
            Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
            this.target = this.towerController.TowerTargeting.NearestEnemy;
        }
        
         
        protected virtual void Looking()
        {
            if (this.isDisable) return;
            if (this.target == null) return; 
            Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerController.Rotator.position;
            Vector3 newDirection = Vector3.RotateTowards(
                this.towerController.Rotator.forward, 
                directionToTarget, 
                rotationSpeed * Time.fixedDeltaTime, 0.0f);
            
            this.towerController.Rotator.rotation = Quaternion.LookRotation(newDirection);
        }
        
        protected virtual void Shooting()
        {
            if (this.isDisable) return;
            
            Invoke(nameof(this.Shooting), this.shootingSpeed + Random.Range(-0.1f, 0.1f));
            if (this.target == null) return;
            
            FirePoint firePoint = this.GetFirePoint();
            Vector3 rotatorDirection = this.towerController.Rotator.transform.forward;
            
            // Spawn Bullet
            this.SpawnBullet(firePoint.transform.position, rotatorDirection);
            
            // Spawn Muzzle
            this.SpawnMuzzle(firePoint.transform.position, rotatorDirection);
            
            // Spawn Sound
            this.SpawnSound(firePoint.transform.position);
        }
        
        
        protected virtual void SpawnBullet(Vector3 spawnPoint, Vector3 rotatorDirection)
        {
            EffectController effect = this.effectSpawner.PoolPrefabs.GetByName("Projectile1");
            EffectController newEffect = this.effectSpawner.Spawn(effect, spawnPoint);
            newEffect.transform.forward = rotatorDirection;

            EffectFlyAbtract effectFly = (EffectFlyAbtract)newEffect;
            effectFly.FlyToTarget.SetTarget(this.target.TowerTargetable.transform);

            newEffect.gameObject.SetActive(true);
        }
        
        protected virtual void SpawnMuzzle(Vector3 spawnPoint, Vector3 rotatorDirection)
        {
            EffectController effect = this.effectSpawner.PoolPrefabs.GetByName("Muzzle1");
            EffectController newEffect = this.effectSpawner.Spawn(effect, spawnPoint);
            newEffect.transform.forward = rotatorDirection;
            newEffect.gameObject.SetActive(true);
        }
        
        
        protected virtual FirePoint GetFirePoint()
        {
            FirePoint firePoint = this.towerController.FirePoints[(int) this.currentFirePoint];
            this.currentFirePoint++;
            if (this.currentFirePoint >= this.towerController.FirePoints.Count) this.currentFirePoint = 0;
            return firePoint;
        }

        protected virtual bool IsTargetDead()
        { 
            if (this.target == null) return true;
            if (!this.target.EnemyDamageReceiver.IsDead()) return false;
            this.killCount++;
            this.totalKill++;
            this.target = null;
            return true;
        }
        
        public virtual bool DeductKillCount(int count)
        {
            if (this.KillCount < count) return false;
            this.killCount -= count;
            return true;
        }

        protected virtual void SpawnSound(Vector3 position)
        {
            SfxController newSfx = SoundManager.Instance.CreateSfx(this.shootSfxName);
            newSfx.transform.position = position;
            newSfx.gameObject.SetActive(true);
        }

        public virtual void Active()
        {
            this.isDisable = false;
        }
        
        public virtual void Disable()
        {
            this.isDisable = true;
        }
    }
}
