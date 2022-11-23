using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManagerScript : MonoBehaviour
{
	public GameObject turretPref;
	public Transform player;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.T))
		{
			Debug.Log("생성완료");
			Instantiate(turretPref, player.position + new Vector3(5f,0,5f), player.transform.rotation);
		}
	}
}
