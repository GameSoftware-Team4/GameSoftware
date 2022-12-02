using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
	public static EnemySpawnManager Instance;

	EnemySpawnpoint[] EnemySpawnpoints;

	void Awake()
	{
		Instance = this;
		EnemySpawnpoints = GetComponentsInChildren<EnemySpawnpoint>();
	}

	public Transform GetSpawnpoint()
	{
		return EnemySpawnpoints[Random.Range(0, EnemySpawnpoints.Length)].transform;
	}
}
