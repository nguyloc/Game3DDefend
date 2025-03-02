using UnityEngine;

namespace _Data.Minimap
{
    public class MinimapFollow : MonoBehaviour
    {
        public Transform player;
        float _yCamera;
        
        
        void Start()
        {
            _yCamera = transform.position.y;
        }
        
        void LateUpdate()
        {
            //Aplly position of player to camera
            transform.position = new Vector3(player.position.x, _yCamera, player.position.z);
            
            //Apply rotation of player to camera
            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
    }
}
