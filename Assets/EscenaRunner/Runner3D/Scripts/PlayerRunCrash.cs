using UnityEngine;
using UnityEngine.Events;

public class PlayerRunCrash : MonoBehaviour
{

    [SerializeField] private float fallLimit = -10f;   // más abajo: ha caído

    [SerializeField] UnityEvent OnCrash;
    [SerializeField] UnityEvent OnFall;
    bool hasFallen = false;

    void Update()
    {
        if (transform.position.y < fallLimit && !hasFallen)
        {
            RunGameManager.Instance.GameOver();
            OnFall.Invoke();
            hasFallen = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo"))
        {
            OnCrash.Invoke();
            RunGameManager.Instance.GameOver();
        }
    }
}
