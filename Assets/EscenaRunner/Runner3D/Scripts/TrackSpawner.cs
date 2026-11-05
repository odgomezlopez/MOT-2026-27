using UnityEngine;

public class TrackSpawner : MonoBehaviour
{
    [Header("Track Settings")]
    [SerializeField] GameObject[] tracks;
    [SerializeField] Transform player;

    [SerializeField] float segmentLength = 50f;
    [SerializeField] int segmentsAhead = 4;       // tramos por delante
    [SerializeField] float behindDistance = 20f;  // metros por detrás
    private float nextZ = 0f;                             // dónde va el siguiente

    [Header("Internal")]
    [SerializeField] Vector3 initialPositionPlayer;
    [SerializeField] Vector3 offset = new Vector3(0, -1f, 10f);



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Buscamos al jugador
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //player = FindAnyObjectByType<SideRunner3D>().transform;

        if(!player)
        {
            Debug.LogError("Player not found!");
            return;
        }
        initialPositionPlayer = player.position;

        //Generamos los tramos iniciales por delante del jugador
        for(int i = 0; i < segmentsAhead; i++) { 
            SpawnSegment(); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        //Creo segmentos adelante
        if (nextZ < player.position.z + segmentsAhead * segmentLength)
            SpawnSegment();                                // ← falta pista

        //Si tengo un tramo que ya quedó muy lejos, lo destruyo
        if (transform.GetChild(0).position.z < player.position.z - behindDistance)
            Destroy(transform.GetChild(0).gameObject);     // ← ya quedó lejos
    }
    // Crea un tramo al azar en nextX, como hijo del TrackSpawner
    void SpawnSegment()
    {
        GameObject track = tracks[Random.Range(0, tracks.Length)];
        Vector3 pos = new Vector3(0f, 0, nextZ) + initialPositionPlayer + offset;
        Instantiate(track, pos, Quaternion.identity, transform);
        nextZ += segmentLength;
    }

}
