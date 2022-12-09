using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RocketMangerScript_pwj : MonoBehaviour
{
	public GameObject missilePref;
	public GameManagerScript_pwj gameManger;

	
	
	// �迭�� �����ؼ� �����
	Transform[] shotPosChild;
	public Transform shotPos;
	public Transform shotPos2;
	public Transform shotPos3;

	// �̻��� �ر� ON OFF
	GameObject controller;
	private bool missile1 = false;
	private bool missile2 = false;
	private bool missile3 = false;

	Quaternion quat = Quaternion.identity;
	float delayTime = 3f;
	float checkTime = 0f;
	// Start is called before the first frame update
	void Start()
	{
		missilePref = Resources.Load<GameObject>("pwj_prefab/Missile");
		shotPos = GameObject.Find("RocketManager").transform.Find("Rocket" + 1).transform.Find("RocketSpawner").gameObject.transform;
		shotPos2 = GameObject.Find("RocketManager").transform.Find("Rocket" + 2).transform.Find("RocketSpawner2").gameObject.transform;
		shotPos3 = GameObject.Find("RocketManager").transform.Find("Rocket" + 3).transform.Find("RocketSpawner3").gameObject.transform;
		gameManger = GameObject.Find("Canvas").GetComponent<GameManagerScript_pwj>();

		quat.eulerAngles = new Vector3(90, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		checkTime += Time.deltaTime;
		Shoot();
	}

	void Shoot()
    {
		if (checkTime > delayTime)
		{
			/*GameObject missile = Instantiate(missilePref, shotPos.position + new Vector3(0, 2, 0), shotPos.rotation);*/
			if(missile1)
				controller = PhotonNetwork.Instantiate(Path.Combine("pwj_prefab", "Missile"), shotPos.position + new Vector3(0, 2, 0), shotPos.rotation);
			if (missile2)
				controller = PhotonNetwork.Instantiate(Path.Combine("pwj_prefab", "Missile"), shotPos2.position + new Vector3(0, 2, 0), shotPos2.rotation);
			if (missile3)
				controller = PhotonNetwork.Instantiate(Path.Combine("pwj_prefab", "Missile"), shotPos3.position + new Vector3(0, 2, 0), shotPos3.rotation);
			
			checkTime = 0;
		}

	}
	
	private void CheckEXP()
	{
		int curEXP = gameManger.GetExp();

		if (curEXP > 750 && !missile1)
		{
			GameObject.Find("RocketManager").transform.GetChild(0).gameObject.SetActive(true);
			shotPos = GameObject.Find("RocketManager").transform.Find("Rocket" + 1).transform.Find("RocketSpawner").gameObject.transform;
			missile1 = true;
		}

		if (curEXP > 1500 && !missile2)
		{
			GameObject.Find("RocketManager").transform.GetChild(1).gameObject.SetActive(true);
			shotPos2 = GameObject.Find("RocketManager").transform.Find("Rocket" + 2).transform.Find("RocketSpawner").gameObject.transform;
			missile2 = true;
		}

		if (curEXP > 3000 && !missile3)
		{
			GameObject.Find("RocketManager").transform.GetChild(2).gameObject.SetActive(true);
			shotPos3 = GameObject.Find("RocketManager").transform.Find("Rocket" + 3).transform.Find("RocketSpawner").gameObject.transform;
			missile3 = true;
		}
	}

	private void FixedUpdate()
	{
		CheckEXP();
		transform.RotateAround(transform.position, Vector3.forward, 50 * Time.deltaTime);
	}
}
