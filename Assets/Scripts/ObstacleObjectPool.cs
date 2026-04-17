using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleObjectPool : MonoBehaviour
{
    public GameObject obstacleBarrelPrefab;
    public GameObject obstacleBarrierPrefab;
    public GameObject obstacleStoneWallPrefab;
    public int poolSize = 10;

    public List<GameObject> obstacleBarrelPool;
    public List<GameObject> obstacleBarrierPool;
    public List<GameObject> obstacleStoneWallPool;
    private static ObstacleObjectPool StaticInstance = null;
    public static ObstacleObjectPool GetStatic()
    {
        return StaticInstance;
    }

    void Awake()
    {
        StaticInstance = this;
        obstacleBarrelPool = new List<GameObject>();
        obstacleBarrierPool = new List<GameObject>();
        obstacleStoneWallPool = new List<GameObject>();
    }
    private IEnumerator Start()
    {
        CreatePool();
        yield return null;
    }
    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var intanceBarrel = Instantiate(obstacleBarrelPrefab);
            intanceBarrel.SetActive(false);
            obstacleBarrelPool.Add(intanceBarrel);

            var intanceBarrier = Instantiate(obstacleBarrierPrefab);
            intanceBarrier.SetActive(false);
            obstacleBarrierPool.Add(intanceBarrier);

            var intanceStoneWall = Instantiate(obstacleStoneWallPrefab);
            intanceStoneWall.SetActive(false);
            obstacleStoneWallPool.Add(intanceStoneWall);
        }
    }

    public GameObject Acquire(int obstacleType)
    {
        if( obstacleType == 1 )
        {
            var spawnObstacleBarrel = obstacleBarrelPool[0];
            spawnObstacleBarrel.SetActive(true);
            obstacleBarrelPool.RemoveAt(0);
            return spawnObstacleBarrel;
        }
        else if( obstacleType == 2 )
        {
            var spawnObstacleBarrier = obstacleBarrierPool[0];
            spawnObstacleBarrier.SetActive(true);
            obstacleBarrierPool.RemoveAt(0);
            return spawnObstacleBarrier;
        }
        else if ( obstacleType == 3)
        {
            var spawnObstacleStoneWall = obstacleStoneWallPool[0];
            spawnObstacleStoneWall.SetActive(true);
            obstacleStoneWallPool.RemoveAt(0);
            return spawnObstacleStoneWall;
        }
        else
        {
            return null;
        }
    }

    public void Release(GameObject obstacle, int obstacleType)
    {
        if( obstacleType == 1 )
        {
            obstacleBarrelPool.Add(obstacle);
        }
        else if( obstacleType == 2 )
        {
            obstacleBarrierPool.Add(obstacle);
        }
        else if ( obstacleType == 3 )
        {
            obstacleStoneWallPool.Add(obstacle);
        }

        obstacle.SetActive(false);

    }
}
