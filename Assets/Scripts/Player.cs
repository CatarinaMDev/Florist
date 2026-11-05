using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Character
{
    [SerializeField] private Data_Inventory playerInventory;
    private SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    public void InitializePlayer(Data_Character data)
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        movementSpeed = data.movementSpeed;
        spriteRenderer.sprite = data.characterSprite;
    }
    
    protected override void GetDirection()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movementDirection = new Vector2(moveX, moveY).normalized;
    }

    void OnTriggerEnter2D(Collider2D gameobject)
    {
        if (gameobject.CompareTag("Flower"))
        {
            Flower harvestedFlower = gameobject.GetComponent<Flower>();
            if (harvestedFlower != null)
            {
                Data_Flowers flowerData = harvestedFlower.DataFlower;

                 if (flowerData != null && playerInventory != null  && playerInventory.CanAddItem(flowerData, 1))
                {

                    Debug.Log(" Added Flower " + flowerData.nameOfFlower);
                    playerInventory.AddItem(flowerData, 1);
                    FindFirstObjectByType<InventoryUI>()?.RefreshInventoryUI(); 
                    Destroy(gameobject.gameObject);

                    }
                    else
                    {
                        Debug.LogWarning("Inventory is Full!");
                    }
            }
            
        }
        else if (gameobject.CompareTag("Box"))
        {
            Debug.Log(" found a box");
        }
        else if (gameobject.CompareTag("PlantationSpot"))
        {
            Debug.Log(" found a plantation spot");
        }
        else if (gameobject.CompareTag("Client"))
        {
            Debug.Log(" found a client");
        }
    }

    public void ClearAllInventory()
    {
        if (playerInventory != null)
        {
            playerInventory.ClearInventory();
            FindFirstObjectByType<InventoryUI>()?.RefreshInventoryUI();
            Debug.Log("Inventário limpo com sucesso!");
        }
    }
}