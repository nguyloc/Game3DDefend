using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public abstract class Spawner : LocMonoBehaviour
    {
        
        public virtual Bullet Spawn(Bullet prefab)
        {
            Bullet newObject = Instantiate(prefab);
            return newObject;
        }
        
        public virtual Transform Spawn(Transform prefab)
        {
            Transform newObject = Instantiate(prefab);
            return newObject;
        }
    }
}
