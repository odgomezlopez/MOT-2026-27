using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Jump3D : MonoBehaviour
{
    //Variables
    InputAction jump;
    [SerializeField] private float jumpForce = 5f;

    private bool jumpPressed = false;
    //Referencia a componentes
    private Rigidbody rb;
    private GroundCheckNormal groundCheck;

    [SerializeField] UnityEvent OnJump;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheckNormal>(); // IMPORTANTE  EL INCHILDREN

        jump = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    private void Update()
    {
        if(jump.triggered && groundCheck.IsGrounded())
        {
            jumpPressed = jump.triggered;//true;
        }
    }

    void FixedUpdate()
    {
        if (jumpPressed)
        {
            OnJump.Invoke();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpPressed = false;
        }
    }

}
