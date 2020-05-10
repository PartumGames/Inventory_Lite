using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory_Lite
{
    public class No_Drop_Zone : MonoBehaviour, IDropHandler
    {
        private Drag_Manager manager;


        private void Start()
        {
            manager = FindObjectOfType<Drag_Manager>();
        }


        public void OnDrop(PointerEventData eventData)
        {
            manager.ReturnToSender();
        }
    }
}
