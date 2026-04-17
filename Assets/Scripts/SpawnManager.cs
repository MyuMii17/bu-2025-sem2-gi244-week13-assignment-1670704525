using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject obstaclePrefab;
    private static SpawnManager StaticInstance = null;
    public static SpawnManager GetStatic()
    {
        return StaticInstance;
    }
    void Awake()
    {
        StaticInstance = this;
    }

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 0, 2f);
    }

    void Spawn()
    {
        // 1.18 stop moving left when the game is over
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;
        if (isGameOver)
        {
            return;
        }

        // Instantiate(
        //     obstaclePrefab,
        //     spawnPoint.position,
        //     obstaclePrefab.transform.rotation
        // );

        var obstacleType = Random.Range(1,4);
        Debug.Log(obstacleType);
        var spawn = ObstacleObjectPool.GetStatic().Acquire(obstacleType);
        
        spawn.transform.SetPositionAndRotation(
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}
