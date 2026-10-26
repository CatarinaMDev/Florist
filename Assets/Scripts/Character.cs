using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float movementSpeed = 2f;
    protected Rigidbody2D rb;
    protected Vector2 movementDirection;

    protected virtual void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        GetDirection();
    }

    protected virtual void FixedUpdate()
    {
        if (rb != null)
        {
            rb.linearVelocity = movementDirection * movementSpeed;
        }
    }

    protected virtual void GetDirection()
    {
    }

    protected virtual void Interact()
    {
    }
}