using UnityEngine;

public class FallFaster3D : MonoBehaviour
{
    //Referencia a componentes
    Rigidbody rb;
    //Variable para controlar la velocidad de caida

    [SerializeField, Range(1f,5f)] private float fallMultiplier = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.y < 0f) 
            rb.AddForce(Physics.gravity * (fallMultiplier - 1f), ForceMode.Acceleration);
    }
}
