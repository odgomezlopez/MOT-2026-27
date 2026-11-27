using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Jump2D : MonoBehaviour
{
    //Referencia a componentes
    PlayerStats stats;
    private Rigidbody2D rb;
    private GroundCheck2D groundCheck;

    //Input
    InputAction jump;

    //Variables internas
    private bool jumpPressed = false;
    //Referencia a componentes

    //Eventos
    [SerializeField] UnityEvent OnJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponentInChildren<GroundCheck2D>(); // IMPORTANTE  EL INCHILDREN

        jump = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    private void Update()
    {
        if (jump.triggered && groundCheck.IsGrounded())
        {
            jumpPressed = jump.triggered;//true;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            OnJump.Invoke();
            rb.AddForce(Vector2.up * stats.JumpForce, ForceMode2D.Impulse);
            jumpPressed = false;
        }
    }
}
