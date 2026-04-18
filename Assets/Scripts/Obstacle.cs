using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    public ObstacleData obstacleData;
    public int obstacleType;
    public string obstacleTypeName;
    void Awake()
    {
        gameObject.name = obstacleData.ObstacleDataName;
        obstacleType = obstacleData.ObstacleDataType;
        obstacleTypeName = obstacleData.Type.ToString();
        
    }
}
