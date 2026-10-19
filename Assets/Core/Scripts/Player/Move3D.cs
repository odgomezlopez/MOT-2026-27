using UnityEngine;
using UnityEngine.InputSystem;

public class Move3D : MonoBehaviour
{
    //Variables
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField, Range(0f, 1f)] private float airMomentum = 0.7f;
    [SerializeField, Range(1f, 3f)] private float sprintModifier = 1.5f;

    //Input del jugador
    InputAction move;
    InputAction sprint;

    Vector2 input;

    //Referencias a los componentes del jugador
    Rigidbody rb;
    GroundCheckNormal groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = InputSystem.actions.FindAction("Move");
        sprint = InputSystem.actions.FindAction("Sprint");
        groundCheck = GetComponentInChildren<GroundCheckNormal>(); // IMPORTANTE  EL INCHILDREN
    }

    // Update is called once per frame
    void Update()
    {
        input = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Resumen de elementos que afectan al movimiento:
        Vector3 movement = new Vector3(input.x, 0, input.y);
        bool isSprinting = sprint.IsPressed();
        bool isGrounded = groundCheck.IsGrounded();

        //Calculo de la velocidad de movimiento
        float currentMoveSpeed = moveSpeed * (isSprinting && isGrounded ? sprintModifier : 1f);
        currentMoveSpeed *= isGrounded ? 1f : airMomentum; // Si no esta en el suelo, se reduce la velocidad de movimiento

        rb.linearVelocity = new Vector3(movement.x * currentMoveSpeed, rb.linearVelocity.y, movement.z * currentMoveSpeed);


        //rb.linearVelocity = movement * moveSpeed; // Esto es lo mismo que la línea de arriba, pero no mantiene la velocidad vertical del jugador rb.linearVelocity = new Vector3(movement.x * moveSpeed, 0, movement.z * moveSpeed);
        //rb.AddForce(movement * moveSpeed);
        //transform.Translate(movement * moveSpeed * Time.fixedDeltaTime, Space.World);
        //transform.position += movement * moveSpeed * Time.fixedDeltaTime;
    }
}
