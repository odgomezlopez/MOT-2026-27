using UnityEngine;

public class Flip2D : MonoBehaviour
{
    SpriteRenderer sprite;
    Rigidbody2D rb;

    [SerializeField]bool facingRight = true;

    void Start()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float vx = rb.linearVelocity.x;
        if (facingRight)
        {
            if (vx > 0.1f) sprite.flipX = false;   // ← derecha
            if (vx < -0.1f) sprite.flipX = true;   // ← izquierda
        }
        else
        {
            if (vx > 0.1f) sprite.flipX = true;    // ← derecha
            if (vx < -0.1f) sprite.flipX = false;  // ← izquierda
        }
    }
}
