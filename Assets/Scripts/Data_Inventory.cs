using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlot
{
    public Data_Flowers flowerData;
    public int quantity;

    public InventorySlot(Data_Flowers flower, int amount)
    {
        flowerData = flower;
        quantity = amount;
    }
}


[CreateAssetMenu(fileName = "Data_Inventory", menuName = "ScriptableObjects/Inventory_Information")]
public class Data_Inventory : ScriptableObject
{
    public List<InventorySlot> inventoryItems = new List<InventorySlot>();
    [SerializeField] private int maxStackSize = 10;
    [SerializeField] private int maxTotalSlots = 6;

    public void AddItem(Data_Flowers flowerToAdd, int amount)
    {
        int remainingAmount = amount;

        foreach (var slot in inventoryItems)
        {
            if (slot.flowerData == flowerToAdd && slot.quantity < maxStackSize)
            {
                int spaceInSlot = maxStackSize - slot.quantity;

                if (remainingAmount <= spaceInSlot)
                {
                    slot.quantity += remainingAmount;
                    remainingAmount = 0;
                    break; 
                }
                else
                {
                    slot.quantity = maxStackSize; 
                    remainingAmount -= spaceInSlot; 
                }
            }
        }

        while (remainingAmount > 0)
        {
            int amountToAdd = Mathf.Min(remainingAmount, maxStackSize);
            inventoryItems.Add(new InventorySlot(flowerToAdd, amountToAdd));
            remainingAmount -= amountToAdd;
        }
    }
    public void RemoveItem(Data_Flowers flowerToRemove, int amount)
    {
        int remainingToRemove = amount;

        for (int i = inventoryItems.Count - 1; i >= 0; i--)
        {
            if (inventoryItems[i].flowerData == flowerToRemove)
            {
                if (inventoryItems[i].quantity <= remainingToRemove)
                {
                    
                    remainingToRemove -= inventoryItems[i].quantity;
                    inventoryItems.RemoveAt(i);
                }
                else
                {
                    inventoryItems[i].quantity -= remainingToRemove;
                    remainingToRemove = 0;
                    break; 
                }
            }
            if (remainingToRemove <= 0)
            {
                break;
            }
        }
    }
    public void ClearInventory()
    {
        inventoryItems.Clear();
    }

    public bool CanAddItem(Data_Flowers flowerToAdd, int amount)
    {
        int remainingAmount = amount;
        int simulatedSlotsCount = inventoryItems.Count;

        
        foreach (var slot in inventoryItems)
        {
            if (slot.flowerData == flowerToAdd && slot.quantity < maxStackSize)
            {
                int spaceInSlot = maxStackSize - slot.quantity;
                if (remainingAmount <= spaceInSlot)
                {
                    return true; 
                }
                remainingAmount -= spaceInSlot;
            }
        }

        
        while (remainingAmount > 0)
        {
            if (simulatedSlotsCount >= maxTotalSlots)
            {
                return false; 
            }

            int amountToAdd = Mathf.Min(remainingAmount, maxStackSize);
            simulatedSlotsCount++;
            remainingAmount -= amountToAdd;
        }

        return true;
    }
}
