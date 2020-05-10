using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Inventory_Lite
{
    public class Slot : MonoBehaviour, IPointerClickHandler, IDragHandler, IDropHandler, IBeginDragHandler
    {
        public Image image;
        public Text text;

        public Item myItem;
        public int myAmount;

        private Drag_Manager manager;



        //private void Awake()
        //{
        //    manager = FindObjectOfType<Drag_Manager>();

        //    image = transform.GetChild(0).GetComponent<Image>();
        //    text = transform.GetChild(1).GetComponent<Text>();

        //    UpdateUI();
        //}

        public void Init_Slot()
        {
            manager = FindObjectOfType<Drag_Manager>();

            image = transform.GetChild(0).GetComponent<Image>();
            text = transform.GetChild(1).GetComponent<Text>();

            UpdateUI();
        }

        private void UpdateUI()
        {
            if (myItem != null)
            {
                image.enabled = true;
                text.enabled = true;

                image.sprite = myItem.itemIcon;
                text.text = myAmount.ToString();
            }
            else
            {
                image.enabled = false;
                text.enabled = false;
            }
        }

        public void AddItem(Item _item, int _amnt)
        {
            if(myItem == null)
            {
                myItem = _item;
            }

            myAmount += _amnt;


            UpdateUI();
        }

        public void RemoveItem(int _amnt)
        {
            myAmount -= _amnt;

            if (myAmount <= 0)
            {
                myItem = null;
            }

            UpdateUI();
        }

        #region Events
        public void OnPointerClick(PointerEventData eventData)
        {
            //TODO: Add you specific code for your game here. IE, Equip an Item, drop an item etc.

            if(eventData.button == PointerEventData.InputButton.Left)
            {
                Debug.Log("Slot: LFT Clicked");
            }

            if (eventData.button == PointerEventData.InputButton.Middle)
            {
                Debug.Log("Slot: MIDDLE Clicked");
            }

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                Debug.Log("Slot: RTE Clicked");
            }

        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            manager.StartDrag(myItem, myAmount, this);
            RemoveItem(myAmount);
        }

        public void OnDrag(PointerEventData eventData)
        {
            manager.DuringDrag();
        }

        public void OnDrop(PointerEventData eventData)
        {
            manager.EndDrag();

            if(myItem == null || myItem == manager.dragItem)
            {
                AddItem(manager.dragItem, manager.dragAmnt);
            }
            else
            {
                manager.ReturnToSender();
            }

            
        }
        #endregion
    }
}
