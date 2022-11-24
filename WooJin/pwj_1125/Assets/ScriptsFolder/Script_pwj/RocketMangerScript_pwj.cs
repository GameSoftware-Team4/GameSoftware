using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMangerScript_pwj : MonoBehaviour
{
	public GameObject missilePref;
	public GameManagerScript_pwj gameManger;
	// 배열로 선언해서 만들기
	public Transform shotPos;
	public Transform shotPos2;
	public Transform shotPos3;

	// 미사일 해금 ON OFF

	private bool missile1 = false;
	private bool missile2 = false;
	private bool missile3 = false;

	Quaternion quat = Quaternion.identity;
	float delayTime = 1.5f;
	float checkTime = 0f;
	// Start is called before the first frame update
	void Start()
	{
		gameManger = GameObject.Find("GameManager").GetComponent<GameManagerScript_pwj>();
		quat.eulerAngles = new Vector3(90, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		checkTime += Time.deltaTime;

		if (delayTime < checkTime)
		{
			if (missile1)
			{
				GameObject missile = Instantiate(missilePref, shotPos.position + new Vector3(0, 2, 0), shotPos.rotation);
				if (missile2)
					Instantiate(missilePref, shotPos2.position + new Vector3(0, 2, 0), shotPos2.rotation);
				if (missile3)
					Instantiate(missilePref, shotPos3.position + new Vector3(0, 2, 0), shotPos3.rotation);
				checkTime = 0;
			}
		}
	}

	private void CheckEXP()
	{
		int curEXP = gameManger.GetExp();

		if (curEXP > 50 && !missile1)
		{
			GameObject.Find("RocketManager").transform.GetChild(0).gameObject.SetActive(true);
			missile1 = true;
		}

		if (curEXP > 100 && !missile2)
		{
			GameObject.Find("RocketManager").transform.GetChild(1).gameObject.SetActive(true);
			missile2 = true;
		}

		if (curEXP > 200 && !missile3)
		{
			GameObject.Find("RocketManager").transform.GetChild(2).gameObject.SetActive(true);
			missile3 = true;
		}
	}

	private void FixedUpdate()
	{
		CheckEXP();
		transform.RotateAround(transform.position, Vector3.forward, 50 * Time.deltaTime);
	}
}
