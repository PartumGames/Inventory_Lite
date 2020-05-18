# Inventory Lite

### Features: 
* Namespaced
* Drag/Drop Items between Slots and Hotbar
* Hotbar
* Add/Remove Items via code
* Item stacking
* Check if Inventory has / does not have a specific item
* Check how many of specific Item the Inventory has
* Inventory is a Singleton so you can access it from any script
* Uses scriptable objects
* UI prefabs


### Using the Scripts
In order to referance or call a script you will need to include the Inventory_Lite Namspace. 
```cscharp
using Inventory_Lite;
```


### Adding Items
```csharp
Inventory.Instance.AddItem(_someItem, _someAmount);
```
Has a bool return type. 
returns true if adding to the Inventory was successful
returns false if adding to Inventory was unsuccessful


### Removing Items
```csharp
Inventory.Instance.RemoveItem(_someItem, _someAmount);
```
Has a bool return type. 
returns true if removing from the Inventory was successful
returns false if removing from Inventory was unsuccessful


### Does Inventory Have a specific Item
```csharp
Inventory.Instance.HasItem(_someItem);
```
returns true if Inventory does have that specific item, false if not


### How Many of a Specific Item does the Inventory Have
```csharp
Inventory.Instance.HasHowMany(_someItem);
```
returns and int that represents how many of a specific Item the Inventory has. 0 if the Inventory does not have that specific Item. 


### Mouse Click Events for Slots
The slot script controls the Inventory Slot. You will have to add your own game specific logic to that script. Whenever a mouse click event happens. 

Find the Slot.cs script. Open it up, and find the OnPointerClick()

```csharp
  public void OnPointerClick(PointerEventData eventData)
        {
            //TODO: Add you specific code for your game here. IE, Equip an Item, drop an item etc.

            if(eventData.button == PointerEventData.InputButton.Left)
            {
                //TODO: Left Mouse Button Click event
                Debug.Log("Slot: LFT Clicked");
            }

            if (eventData.button == PointerEventData.InputButton.Middle)
            {
                //TODO: Middle Mouse Button Click event
                Debug.Log("Slot: MIDDLE Clicked");
            }

            if (eventData.button == PointerEventData.InputButton.Right)
            {
                //TODO: Right Mouse Button Click event
                Debug.Log("Slot: RTE Clicked");
            }

        }
```
Then simply remove the //TODO and the Debug.Log(), and add in your specific code. 


### Item Database Script
This script is used mostly for adding items to the Inventory for testing. It is hard coded to add a random item to the Inventory when you press the "G" key. 


### Things to remember

The Inventory.Instance is a static referance to the Inventory class (Singleton). It does not however take adavantage of the   
 ```csharp
DontDestroyOnLoad(this);
```
This means your inventory will be destroyed when the scene changes. 




