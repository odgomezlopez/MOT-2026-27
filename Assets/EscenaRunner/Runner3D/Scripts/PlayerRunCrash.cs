using UnityEngine;

public class PlayerRunCrash : MonoBehaviour
{

    [SerializeField] private float fallLimit = -10f;   // más abajo: ha caído
    void Update()
    {
        if (transform.position.y < fallLimit)
            RunGameManager.Instance.GameOver();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            RunGameManager.Instance.GameOver();
        }
    }
}
