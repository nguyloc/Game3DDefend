using UnityEngine;

namespace _Data.Tower.Scripts
{
    public class BulletSpawner : Spawner
    {
        public virtual Bullet Spawn(Bullet bulletPrefab)
        {
            Bullet newObject = Instantiate(bulletPrefab);
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
