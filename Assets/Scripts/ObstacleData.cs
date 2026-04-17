using UnityEngine;

public enum obstacleType
    {
        Barrel,
        Barrier,
        StoneWall
    }

[CreateAssetMenu(fileName = "ObstacleScriprs", menuName = "Scriptable Objects/ObstacleScriprs")]
public class ObstacleData : ScriptableObject
{
    [Header("Obstacle Setting")]
    public string ObstacleDataName;
    public int ObstacleDataType;
    public obstacleType Type;
}
