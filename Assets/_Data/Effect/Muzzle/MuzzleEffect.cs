using _Data.Scripts;
using UnityEngine;

namespace _Data.Effect.Muzzle
{
    public class MuzzleEffect : LocMonoBehaviour
    {
        [SerializeField] protected MuzzleCode muzzle;

        protected virtual void OnEnable()
        {
            this.SpawnMuzzle();
        }

        protected virtual void SpawnMuzzle()
        {
            if (this.muzzle == MuzzleCode.NoMuzzle) return;
            EffectSpawner effectSpawner = EffectSpawnerController.Instance.Spawner;
            EffectController prefab = effectSpawner.PoolPrefabs.GetByName(this.muzzle.ToString());
            EffectController newEffect = effectSpawner.Spawn(prefab, transform.position);
            newEffect.gameObject.SetActive(true);
        }
    }
}
