using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;
using System.IO;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
	PhotonView PV;

	GameObject controller;

	int kills;
	int deaths;

	void Awake()
	{
		PV = GetComponent<PhotonView>();
	}

	void Start()
	{
		if(PV.IsMine)
		{
			CreateController();
		}
	}

	void CreateController()
	{ //지정된 스폰위치에서 해당 플레이어 생성
		Transform Enemyspawnpoint = EnemySpawnManager.Instance.GetSpawnpoint();
		controller = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Beholder"), Enemyspawnpoint.position, Enemyspawnpoint.rotation, 0, new object[] { PV.ViewID });


	}

	public void Die()
	{
		Debug.Log("enemy is dead");
		PhotonNetwork.Destroy(controller);
		CreateController();

		deaths++;

		Hashtable hash = new Hashtable();
		hash.Add("deaths", deaths);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
	}

	/*   public void GetKill()
       {
           PV.RPC(nameof(RPC_GetKill), PV.Owner);
       }*/

	[PunRPC]
	void RPC_GetKill()
	{
		kills++;

		Hashtable hash = new Hashtable();
		hash.Add("kills", kills);
		PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
	}

	public static EnemyManager Find(Player player)
    {
    return FindObjectsOfType<EnemyManager>().SingleOrDefault(x => x.PV.Owner == player);
    }
}