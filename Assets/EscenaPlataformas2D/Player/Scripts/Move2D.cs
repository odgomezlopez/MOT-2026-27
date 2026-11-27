using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerStats))]
public class Move2D : MonoBehaviour
{
    //Referencias a los componentes del jugador
    PlayerStats stats;
    Rigidbody2D rb;

    //Input del jugador
    InputAction move;
    InputAction sprint;

    //Variables internas
    Vector2 input;

    void Start()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();

        move = InputSystem.actions.FindAction("Move");
        sprint = InputSystem.actions.FindAction("Sprint");
    }

    // Update is called once per frame
    void Update()
    {
        input = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        // Resumen de elementos que afectan al movimiento:
        Vector2 movement = new Vector2(input.x, 0);
        bool isSprinting = sprint.IsPressed();

        bool isGrounded = true;// groundCheck.IsGrounded();

        //Calculo de la velocidad de movimiento
        float currentMoveSpeed = stats.MoveSpeed * (isSprinting && isGrounded ? stats.SprintModifier : 1f);
        //currentMoveSpeed *= isGrounded ? 1f : airMomentum; // Si no esta en el suelo, se reduce la velocidad de movimiento

        rb.linearVelocity = new Vector2(movement.x * currentMoveSpeed, rb.linearVelocity.y);
    }
}
