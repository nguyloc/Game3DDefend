using UnityEngine;

namespace _Data.Minimap
{
    public class MinimapFollow : MonoBehaviour
    {
        [Header("Minimap Camera")]
        public Transform player;             // Nhân vật
        public Transform minimapCamera;      // Camera Minimap

        [Header("Minimap UI")]
        public RectTransform minimapPanel;   // Panel Minimap (UI)
   

  
        void Update()
        {
            if (player == null) return;

            // 🎯 **Di chuyển minimap camera theo nhân vật**
            if (minimapCamera != null)
            {
                minimapCamera.position = new Vector3(player.position.x, minimapCamera.position.y, player.position.z);
            }
            
        }
    }
}
