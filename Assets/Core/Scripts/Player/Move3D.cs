using UnityEngine;
using UnityEngine.InputSystem;

public class Move3D : MonoBehaviour
{
    //Variables
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;

    //Input del jugador
    InputAction move;
    Vector2 input;

    //Referencias a los componentes del jugador
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        input = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.x, 0, input.y);
        rb.linearVelocity = new Vector3(movement.x * moveSpeed, rb.linearVelocity.y, movement.z * moveSpeed);


        //rb.linearVelocity = movement * moveSpeed; // Esto es lo mismo que la línea de arriba, pero no mantiene la velocidad vertical del jugador rb.linearVelocity = new Vector3(movement.x * moveSpeed, 0, movement.z * moveSpeed);
        //rb.AddForce(movement * moveSpeed);
        //transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);
        //transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}
