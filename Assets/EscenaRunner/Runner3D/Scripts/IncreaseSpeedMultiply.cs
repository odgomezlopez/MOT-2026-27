using UnityEngine;

public class IncreaseSpeedMultiply : MonoBehaviour
{
    [SerializeField] float penalty = 50f;

    private void OnTriggerEnter(Collider other)
    {
        SideRunner3D sideRunner3D = other.GetComponentInParent<SideRunner3D>();
        if (sideRunner3D)
        {
            sideRunner3D.IncreaseSpeed(penalty);
            Destroy(gameObject);
        }
    }
}
