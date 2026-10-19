using UnityEngine;

// Sube escalones bajos: si abajo choca y a la altura del escalón no, sube un poco
[RequireComponent(typeof(Rigidbody)), DefaultExecutionOrder(100)]
public class StepClimber : MonoBehaviour
{
    //Componentes
    GroundCheckNormal groundCheck;

    //Variables

    [SerializeField] float stepHeight = 0.3f;    // el escalón más alto
    [SerializeField] float stepUp = 0.1f;        // cuánto sube cada vez
    [SerializeField] float rayLength = 0.6f;     // radio de la cápsula + 0,1
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponentInChildren<GroundCheckNormal>();

    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (dir.sqrMagnitude < 0.01f) return;    // quieto: nada que subir

        dir.Normalize();
        Vector3 low = groundCheck.transform.position;
        Vector3 high = low + Vector3.up * stepHeight;
        bool lowHit = Physics.Raycast(low, dir, rayLength, groundCheck.groundLayer);
        bool highHit = Physics.Raycast(high, dir, rayLength, groundCheck.groundLayer);
        if (lowHit && !highHit) rb.position += Vector3.up * stepUp;
    }
}
