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
			Debug.Log("터렛 생성 완료");
			Instantiate(turretPref, player.transform.position + new Vector3(2.0f, 0f, 2.0f), transform.rotation);
        }
	}
}
