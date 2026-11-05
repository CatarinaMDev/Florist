using UnityEngine;
using UnityEngine.UI; 
using TMPro;         

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Data_Inventory playerInventory; 
    [SerializeField] private Transform slotsParent;            
    [SerializeField] private GameObject slotUIPrefab;          

    [SerializeField] private TextMeshProUGUI descriptionText;  

    public void DisplayItemInfo(Data_Flowers item)
    {
        if (descriptionText != null)
        {
            if (item != null)
            {
                descriptionText.text = item.nameOfFlower;
            }
            else
            {
                descriptionText.text = "";
            }
        }
    }

    public void RefreshInventoryUI()
    {
        if (slotsParent == null || slotUIPrefab == null || playerInventory == null)
        {
            Debug.LogWarning("Faltam referências no InventoryUI!");
            return;
        }

        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var slot in playerInventory.inventoryItems)
        {
            GameObject newSlotObj = Instantiate(slotUIPrefab, slotsParent);

            Image flowerIcon = newSlotObj.transform.Find("Icon")?.GetComponent<Image>();
            TMP_Text quantityText = newSlotObj.transform.Find("Quantity")?.GetComponent<TMP_Text>();

            if (slot.flowerData != null)
            {
                if (flowerIcon != null)
                {
                    flowerIcon.sprite = slot.flowerData.flowerSprite;
                }

                if (quantityText != null)
                {
                    quantityText.text = slot.quantity > 1 ? slot.quantity.ToString() : "";
                }
            }
        }
    }
}