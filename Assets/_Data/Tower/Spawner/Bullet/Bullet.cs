using _Data.Tower.Scripts;
using UnityEngine;

namespace _Data.Tower.Spawner.Bullet
{
    public class Bullet : PoolObj
    {
        [SerializeField] protected float speed = 10f;
        
        void Update()
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }

        public override string GetName()
        {
            return "Bullet";
        }
    }
}
