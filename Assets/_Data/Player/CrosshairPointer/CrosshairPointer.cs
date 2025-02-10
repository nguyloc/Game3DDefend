using System;
using UnityEngine;

namespace _Data.Player.CrosshairPointer
{
    public class CrosshairPointer : MonoBehaviour
    {
        protected float maxDistance = 100f;
        protected Collider hitObj;
        [SerializeField] LayerMask layerMask = -1;

        protected virtual void Update()
        {
            this.Pointing();
        }
        
        protected virtual void Pointing()
        {
            Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, layerMask))
            {
                transform.position = hit.point;
                this.hitObj = hit.collider;
            }
        }
    }
}
