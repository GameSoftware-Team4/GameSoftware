using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpCapsuleScript : MonoBehaviour
{
	GameManagerScript_pwj gameManager;
	Vector3 playerTransform;
	Vector3 vel = Vector3.zero;
	bool tangetial = false;
	Vector3 vc;
	// Start is called before the first frame update
	void Start()
	{
		vc = new Vector3(1f, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(vc);
        if (tangetial)
        {
			// 플레이어에게 붙으면 Destroy!!
			transform.position = Vector3.SmoothDamp(transform.position, playerTransform, ref vel, 1f);
		}
		Destroy(gameObject, 60f);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerTransform = other.transform.position;
			tangetial = true;
			Debug.Log("경험치 획득!");
			// transform.position = other.transform.position;
			// transform.position = Vector3.SmoothDamp(transform.position, other.transform.position, ref vel, 10f);
			gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript_pwj>();
			// if (gameManager != null) { gameManager.SetExp(); Destroy(gameObject); return; }
			if (gameManager != null) { gameManager.SetExp(); return; }
		}
	}
}
