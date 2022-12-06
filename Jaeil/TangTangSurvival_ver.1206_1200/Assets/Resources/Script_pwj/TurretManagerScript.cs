using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class TurretManagerScript : MonoBehaviour
{
	public GameObject turretPref;
	public GameObject player;
    // Update is called once per frame

    private void Start()
    {
        turretPref = Resources.Load<GameObject>("pwj_prefab/TurretPref");
        player = transform.gameObject;
    }
    void Update()
	{
        if (Input.GetKeyDown(KeyCode.V))
        {
			Debug.Log("터렛 생성 완료");
			PhotonNetwork.Instantiate(Path.Combine("pwj_prefab", "TurretPref"), player.transform.position + new Vector3(2.0f, 0f, 2.0f), transform.rotation);
        }
	}
}
