using _Data.Scripts;
using UnityEngine;

namespace _Data.Tower.Scripts
{
    public abstract class Spawner : LocMonoBehaviour
    {
        public virtual Transform Spawn(Transform prefab)
        {
            Transform newObject = Instantiate(prefab);
            return newObject;
        }
    }
}
