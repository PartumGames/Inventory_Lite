using System.Collections.Generic;
using UnityEngine;

namespace Inventory_Lite
{
    public class Inventory : MonoBehaviour
    {
        public static Inventory Instance;

        public List<Slot> slots = new List<Slot>();

        public GameObject inventoryBGPanel;
        public Transform inventoryPanel;

        public KeyCode toggleInventoryKey;

        private bool isVisible;


        private void Awake()
        {
            Instance = this;

            isVisible = inventoryBGPanel.activeInHierarchy;

            foreach (Transform item in inventoryPanel.transform)
            {
                Slot slot = item.GetComponent<Slot>();
                slots.Add(slot);
                slot.Init_Slot();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(toggleInventoryKey))
            {
                ToggleInventory();
            }
        }

        private void ToggleInventory()
        {
            isVisible = !isVisible;
            inventoryBGPanel.SetActive(isVisible);
        }

        public bool AddItem(Item _item, int _amnt)
        {
            Slot firstEmpy = null;

            foreach (Slot slot in slots)
            {
                if(slot.myItem == _item)
                {
                    if (_item.canStack)
                    {
                        slot.AddItem(_item, _amnt);
                        return true;
                    }
                }

                if(slot.myItem == null && firstEmpy == null)
                {
                    firstEmpy = slot;
                }
            }

            if (firstEmpy != null)
            {
                firstEmpy.AddItem(_item, _amnt);
                return true;
            }
            else
            {
                Debug.Log("Inventory is full");
                return false;
            }
        }

        public bool RemoveItem(Item _item, int _amnt)
        {
            foreach (Slot slot in slots)
            {
                if(slot.myItem == _item)
                {
                    slot.RemoveItem(_amnt);
                    return true;
                }
            }

            return false;
        }

        public bool HasItem(Item _item)
        {
            foreach (Slot slot in slots)
            {
                if(slot.myItem == _item)
                {
                    return true;
                }
            }

            return false;
        }

        public int HasHowMany(Item _item)
        {
            foreach (Slot slot in slots)
            {
                if (slot.myItem == _item)
                {
                    return slot.myAmount;
                }
            }

            return 0;
        }
    }
}
