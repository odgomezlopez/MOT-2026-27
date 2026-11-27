using UnityEngine;

public class GroundCheck2D : MonoBehaviour
{
    //Variables para saber si esta en el suelo
    [SerializeField] private bool isGrounded = false;
    public bool IsGrounded() { return isGrounded; }

    //Capa sobre la cual se puede saltar
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        //1. Lanzo un raycast hacia abajo para ver si esta en el suelo
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            Vector2.down, groundCheckDistance, groundLayer);

        //2. Si el raycast colisiona con algo, entonces esta en el suelo
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //3 . Dibujo el raycast en la escena para ver si esta en el suelo
        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, isGrounded ? Color.green : Color.red, 0.5f);
        //Debug.DrawRay
    }
}
