using _Data.Tower.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner
{
    public class BulletSpawner : Spawner<Bullet>
    {
        public virtual Bullet Spawn(Bullet bulletPrefab)
        {
            Bullet newObject = Instantiate(bulletPrefab);
            newObject.Despawn.SetSpawner(this);
            return newObject;
        }
        
        public virtual Bullet Spawn(Bullet buletPrefab, Vector3 position)
        { 
            Bullet newBullet = this.Spawn(buletPrefab); 
            newBullet.transform.position = position; 
            return newBullet;
        }
    }
}
