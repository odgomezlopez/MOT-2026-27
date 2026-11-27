using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Movimiento")]
    public float MoveSpeed = 5f;
    public float SprintModifier = 1.5f;
    public float AirMomentum = 0.7f;

    [Header("Salto")]
    public float JumpForce = 10f;
}
