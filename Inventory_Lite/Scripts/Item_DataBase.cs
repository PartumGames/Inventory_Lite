using System.Collections.Generic;
using UnityEngine;

namespace Inventory_Lite
{
    public class Item_DataBase : MonoBehaviour
    {
        public List<Item> items = new List<Item>();


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                AddItem(Random.Range(0, items.Count));
            }
        }


        public void AddItem(int _index)
        {
            Inventory.Instance.AddItem(items[_index], 1);
        }

        public void AddItem(string _name)
        {
            foreach (Item item in items)
            {
                if (item.name == _name)
                {
                    Inventory.Instance.AddItem(item, 1);
                }
            }
        }
    }
}