using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityNightPool;

public class MapGenerator : MonoBehaviour
{
    public static MapGenerator instance = null;

    [SerializeField] private List<Vector3> spawnPositions;

    private List<bool> activeWall;
    private int jumpMutex = 0;

    private float durationWall = 3f;

    public float DurationWall => durationWall;

    private void Start()
    {
        if (instance == null) { instance = this; }

        activeWall = new List<bool>();
        for(int i = 0, end = spawnPositions.Count; i < end; ++i)
        {
            activeWall.Add(true);
        }

        StartCoroutine(SpawnWall());
    }

    private IEnumerator SpawnWall()
    {
        while (true)
        {
            ChangeActiveWall();

            jumpMutex = Random.Range(0, spawnPositions.Count + 1);
            for (int i = 0, end = spawnPositions.Count; i < end; ++i)
            {
                if (activeWall[i])
                {
                    if (jumpMutex != i)
                    {
                        PoolManager.Get(PoolID.Wall).transform.position = spawnPositions[i];
                    }
                    else
                    {

                        PoolManager.Get(PoolID.Wall).transform.position =
                            new Vector3(spawnPositions[i].x, spawnPositions[i].y + 5, spawnPositions[i].z);
                    }
                }
            }
            yield return new WaitForSeconds(1.5f); 
        }
    }

    private void ChangeActiveWall()
    {
        bool activate = true;
        int count = 0;

        foreach(bool active in activeWall)
        {
            if (active) { ++count; }
        }

        if (count > 1) { activate = false;}
        if (Random.Range(0, 2) == 0) { activate = true; }

        activeWall[Random.Range(0, activeWall.Count)] = activate;
    }

    private static bool ActiveWall(bool active)
    {
        return active;
    }
}
