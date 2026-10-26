using UnityEngine;

public class Cat : Character
{

    private float timer = 0f;

    protected override void GetDirection()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);

            movementDirection = new Vector2(randomX, randomY);

            timer = Random.Range(1.5f, 4f);
        }
    }
}
