using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMangerScript_pwj: MonoBehaviour
{
	public GameObject missilePref;
	// 배열로 선언해서 만들기
	public Transform shotPos;
	public Transform shotPos2;
	public Transform shotPos3;
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
			// Vector3 yDir = shotPos.position + new Vector3(0, 2, 0);
			GameObject missile = Instantiate(missilePref, shotPos.position + new Vector3(0, 2, 0), shotPos.rotation);
			missile = Instantiate(missilePref, shotPos2.position + new Vector3(0, 2, 0), shotPos2.rotation);
		}
	}
}
