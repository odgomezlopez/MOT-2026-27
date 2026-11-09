using UnityEngine;

public class AnimatorPlayerConnector : MonoBehaviour
{
    //Variables
    [SerializeField]
    float walkThreshold = 2f;
    [SerializeField]
    float runThreshold = 5f;

    //Referencias a componentes del jugador
    Rigidbody rb;
    Animator animator;
    GroundCheckNormal groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        groundCheck = GetComponentInChildren<GroundCheckNormal>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.linearVelocity;
        float speed = new Vector3(v.x, 0f, v.z).magnitude;      // solo la horizontal

        // Cambiar el parámetro Velocity del Animator según la velocidad del jugador
        if (speed > runThreshold) animator.SetFloat("Velocity", 2.1f);         //Correr
        else if (speed > walkThreshold) animator.SetFloat("Velocity", 1.1f); //Andar
        else animator.SetFloat("Velocity", 0f); //IDLE
        //animator.SetFloat("Velocity", speed); //IDLE

        animator.SetBool("IsGrounded", groundCheck.IsGrounded());

        if (speed > 0.1f)                                       // que mire hacia donde corre
            animator.transform.forward = new Vector3(v.x, 0f, v.z);
    }
}
