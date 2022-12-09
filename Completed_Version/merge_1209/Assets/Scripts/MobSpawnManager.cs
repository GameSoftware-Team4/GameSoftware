using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawnManager : MonoBehaviour
{
    public static MobSpawnManager Instance;

    Spawnpoint[] spawnpoints;

    void Awake()
    {
        Instance = this;
        spawnpoints = GetComponentsInChildren<Spawnpoint>();
    }

    public Transform GetSpawnpoint()
    {
        return spawnpoints[Random.Range(0, spawnpoints.Length)].transform;
    }
}
