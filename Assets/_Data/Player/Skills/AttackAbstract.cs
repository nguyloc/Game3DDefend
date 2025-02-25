using System;
using _Data.Effect;
using _Data.Player.Scripts;
using _Data.Scripts;
using UnityEngine;


namespace _Data.Player.Skills
{
    public abstract class AttackAbstract : LocMonoBehaviour
    {
        [SerializeField] protected PlayerController playerController;
        [SerializeField] protected EffectSpawner spawner;
        [SerializeField] protected EffectPrefabs prefabs;

        protected void LateUpdate()
        {
            this.Attacking();
        }
        
        protected abstract void Attacking();
        
        protected override void LoadComponents()
        {
            base.LoadComponents();
            this.LoadPlayerController();
            this.LoadEffectSpawner();
        }
        
        protected virtual void LoadEffectSpawner()
        {
            if (this.spawner != null) return;
            this.spawner = GameObject.FindAnyObjectByType<EffectSpawner>();
            this.prefabs = GameObject.FindAnyObjectByType<EffectPrefabs>();
        }
        
        protected virtual void LoadPlayerController()
        {
            if (this.playerController != null) return;
            this.playerController = GetComponentInParent<PlayerController>();
        }

        protected virtual AttackPoint GetAttackPoint()
        {
            return this.playerController.Weapons.GetCurrentWeapon().AttackPoint;
        }
    }
}
