using UnityEngine;
using UnityEngine.InputSystem;


public class Player : Character
{
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
}