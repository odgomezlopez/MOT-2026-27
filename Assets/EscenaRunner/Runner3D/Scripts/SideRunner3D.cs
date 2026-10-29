using UnityEngine;

public class SideRunner3D : MonoBehaviour
{
    //Variables
    [SerializeField, Min(0f)] private float speed = 10f;
    [SerializeField] private Vector3 direction = Vector3.forward;

    //Referencias a los componentes del jugador
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Calculamos el movimiento del jugador en la dirección especificada y con la velocidad definida
        Vector3 movement = direction.normalized * speed;
        movement.y = rb.linearVelocity.y; // Mantener la velocidad vertical actual del jugador

        //Aplicar la velocidad de movimiento al Rigidbody del jugador
        rb.linearVelocity = movement;
    }
}
