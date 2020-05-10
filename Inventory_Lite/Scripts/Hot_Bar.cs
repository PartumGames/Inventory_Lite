using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory_Lite
{
    public class Hot_Bar : MonoBehaviour
    {
        public GameObject hotBarPanel;
        public List<Slot> slots = new List<Slot>();

        public KeyCode item00Key;
        public KeyCode item01Key;
        public KeyCode item02Key;
        public KeyCode item03Key;
        public KeyCode item04Key;



        private void Start()
        {
            foreach (Transform item in hotBarPanel.transform)
            {
                Slot slot = item.GetComponent<Slot>();
                slots.Add(slot);
                slot.Init_Slot();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(item00Key))
            {
                HandleItem(0);
            }

            if (Input.GetKeyDown(item01Key))
            {
                HandleItem(1);
            }

            if (Input.GetKeyDown(item02Key))
            {
                HandleItem(2);
            }

            if (Input.GetKeyDown(item03Key))
            {
                HandleItem(3);
            }

            if (Input.GetKeyDown(item04Key))
            {
                HandleItem(4);
            }
        }

        private void HandleItem(int _slotIndex)
        {
            if(slots[_slotIndex].myItem != null)
            {
                Debug.Log("Do something with the item in slot #" + _slotIndex);
            }
        }
    }
}
