using UnityEngine;
using UnityEngine.EventSystems;

namespace _Data.Inventory
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Transform parentToReturnTo = null;
        private CanvasGroup canvasGroup;

        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            parentToReturnTo = this.transform.parent;
            this.transform.SetParent(this.transform.root);
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            this.transform.SetParent(parentToReturnTo);
            canvasGroup.blocksRaycasts = true;
        }
    }
}
