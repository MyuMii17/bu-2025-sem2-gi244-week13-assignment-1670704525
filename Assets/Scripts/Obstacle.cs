using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    public ObstacleData obstacleData;
    public int obstacleType;
    private static Obstacle StaticInstance = null;
    public static Obstacle GetStatic()
    {
        return StaticInstance;
    }
    void Awake()
    {
        gameObject.name = obstacleData.ObstacleDataName;
        obstacleType = obstacleData.ObstacleDataType;
        StaticInstance = this;
    }
}
