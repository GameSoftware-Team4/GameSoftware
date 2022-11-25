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
			// ???????????? ?????? Destroy!!
			transform.position = Vector3.SmoothDamp(transform.position, playerTransform, ref vel, 0.1f);
		}
		Destroy(gameObject, 60f);
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			playerTransform = other.transform.position;
			tangetial = true;
			Debug.Log("?????? ????!");
			// transform.position = other.transform.position;
			// transform.position = Vector3.SmoothDamp(transform.position, other.transform.position, ref vel, 10f);
			gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript_pwj>();
			// if (gameManager != null) { gameManager.SetExp(); Destroy(gameObject); return; }
			if (gameManager != null) { gameManager.SetExp(); Destroy(gameObject, 0.3f); return; }
		}
	}
}
