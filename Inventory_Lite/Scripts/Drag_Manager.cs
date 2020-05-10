using UnityEngine;
using UnityEngine.UI;

namespace Inventory_Lite
{
    public class Drag_Manager : MonoBehaviour
    {
        public Image dragIcon;

        [HideInInspector] public Item dragItem { get; private set; }
        [HideInInspector] public int dragAmnt { get; private set; }
        [HideInInspector] public Slot sendingSlot { get; private set; }


        private void Start()
        {
            dragIcon.gameObject.SetActive(false);
        }

        public void StartDrag(Item _item, int _amnt, Slot _slot)
        {
            dragItem = _item;
            dragAmnt = _amnt;
            sendingSlot = _slot;

            dragIcon.gameObject.SetActive(true);
            dragIcon.sprite = dragItem.itemIcon;
        }

        public void DuringDrag()
        {
            dragIcon.transform.position = Input.mousePosition;
        }

        public void EndDrag()
        {
            dragIcon.gameObject.SetActive(false);
        }

        public void ReturnToSender()
        {
            EndDrag();
            sendingSlot.AddItem(dragItem, dragAmnt);
        }
    }
}
