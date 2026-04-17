using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private Obstacle obstacle;
    public float speed = 10f;
    // Update is called once per frame
    void Awake()
    {
        obstacle = gameObject.GetComponent<Obstacle>();
    }
    void Update()
    {
        // 1.17 stop moving left when the game is over
        GameObject player = GameObject.Find("Player");
        bool isGameOver = player.GetComponent<PlayerController>().gameOver;
        if (isGameOver)
        {
            speed = 0;
        }

        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if ( obstacle != null &&transform.position.x < -15 && gameObject.CompareTag("Obstacle"))
        {
            ObstacleObjectPool.GetStatic().Release(gameObject, obstacle.obstacleType);
        }
    }
}
