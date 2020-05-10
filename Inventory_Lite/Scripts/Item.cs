using UnityEngine;


namespace Inventory_Lite
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public string itemName;
        public string itemDescription;

        public Sprite itemIcon;

        public int itemCost;

        public bool canStack;

        public int quantity;
    }
}
