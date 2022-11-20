using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMangerScript_pwj: MonoBehaviour
{
	public GameObject missilePref;
	public Transform shotPos;
	Quaternion quat = Quaternion.identity;
	// Start is called before the first frame update
	void Start()
	{
		quat.eulerAngles = new Vector3(90, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{        
		if (Input.GetKeyDown(KeyCode.Q))
		{
			Vector3 yDir = shotPos.position + new Vector3(0, 2, 0);
			GameObject missile = Instantiate(missilePref, yDir, shotPos.rotation);
		}
	}
}
