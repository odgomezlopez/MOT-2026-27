using DesignPatterns.Singleton;
using UnityEngine;

public class DistanceManager : Singleton<DistanceManager>
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 initialPositionPlayer;
    [SerializeField] float distance;

    public float Distance { get => distance;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialPositionPlayer = player.position;
        distance = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.position.z - initialPositionPlayer.z;
    }
}
