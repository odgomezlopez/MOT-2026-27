using UnityEngine;

public class GroundCheckNormal : MonoBehaviour
{
    //Variables para saber si esta en el suelo
    [SerializeField] private bool isGrounded = false;
    public bool IsGrounded(){ return isGrounded;}

    //Capa sobre la cual se puede saltar
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        //1. Lanzo un raycast hacia abajo para ver si esta en el suelo
        Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, groundCheckDistance, groundLayer);

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
        //Debug.DrawRay(transform.position, Vector3.down * groundCheckDistance, isGrounded ? Color.green : Color.red, 0.5f);
    }
}
