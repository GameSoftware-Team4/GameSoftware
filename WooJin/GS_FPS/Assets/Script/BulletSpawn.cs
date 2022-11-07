using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
	public GameObject bulletpref;
	public Transform shotPos;
	public Transform player;
	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("발사발사");
			GameObject bullet = Instantiate(bulletpref, player.transform.position, player.transform.rotation);
			bullet.transform.position = shotPos.transform.position;
			

			bullet.GetComponent<Rigidbody>().AddForce(shotPos.forward * 5, ForceMode.Impulse);
		}
	}

}
