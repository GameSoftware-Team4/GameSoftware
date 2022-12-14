using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class EnemyController : MonoBehaviourPunCallbacks, IDamageable
{
	[SerializeField] Image healthbarImage;
	[SerializeField] GameObject ui;

	[SerializeField] GameObject cameraHolder;

	[SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;

	[SerializeField] Item[] items;

	int itemIndex;
	int previousItemIndex = -1;

	/*float verticalLookRotation;
	bool grounded;*/
	Vector3 smoothMoveVelocity;
	Vector3 moveAmount;

	Rigidbody rb;

	PhotonView PV;

	const float maxHealth = 100f;
	float currentHealth = maxHealth;

	EnemyManager enemyManager;

	void Awake()
	{
		rb = GetComponent<Rigidbody>();
		PV = GetComponent<PhotonView>();

		enemyManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<EnemyManager>();
	}

	void Start()
	{
		if(PV.IsMine)
		{
		/*	EquipItem(0);*/
		}
		else
		{
			Destroy(GetComponentInChildren<Camera>().gameObject);
			Destroy(rb);
			Destroy(ui);
		}
	}

	void Update()
	{
		if(!PV.IsMine)
			return;

	/*	Look();
		Move();
		Jump();*/

		/*for(int i = 0; i < items.Length; i++)
		{
			if(Input.GetKeyDown((i + 1).ToString()))
			{
				EquipItem(i);
				break;
			}
		}

		if(Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
		{
			if(itemIndex >= items.Length - 1)
			{
				EquipItem(0);
			}
			else
			{
				EquipItem(itemIndex + 1);
			}
		}
		else if(Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
		{
			if(itemIndex <= 0)
			{
				EquipItem(items.Length - 1);
			}
			else
			{
				EquipItem(itemIndex - 1);
			}
		}

		if(Input.GetMouseButtonDown(0))
		{
			items[itemIndex].Use();
		}*/

		if(transform.position.y < -10f) // Die if you fall out of the world
		{
			Die();
		}
	}

	

	/*void EquipItem(int _index)
	{
		if(_index == previousItemIndex)
			return;

		itemIndex = _index;

		items[itemIndex].itemGameObject.SetActive(true);

		if(previousItemIndex != -1)
		{
			items[previousItemIndex].itemGameObject.SetActive(false);
		}

		previousItemIndex = itemIndex;

		if(PV.IsMine)
		{
			Hashtable hash = new Hashtable();
			hash.Add("itemIndex", itemIndex);
			PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
		}
	}*/

	/*public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
	{
		if(changedProps.ContainsKey("itemIndex") && !PV.IsMine && targetPlayer == PV.Owner)
		{
			EquipItem((int)changedProps["itemIndex"]);
		}
	}*/

/*	public void SetGroundedState(bool _grounded)
	{
		grounded = _grounded;
	}*/

	void FixedUpdate() //fps에 영향을 받지않도록설정
	{
		if(!PV.IsMine)
			return;

		rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
	}

	public void TakeDamage(float damage)//제작자의 컴퓨터에서만 해당정보를 계산
	{
		PV.RPC(nameof(RPC_TakeDamage), PV.Owner, damage);// pv의 주인한테 pv.rpc의 데미지 정보를 전달
	}

	[PunRPC]
	void RPC_TakeDamage(float damage, PhotonMessageInfo info)// 피해자의 컴퓨터 내에서 해당 데미지 처리
	{
		currentHealth -= damage;

		/*healthbarImage.fillAmount = currentHealth / maxHealth;*/

		if(currentHealth <= 0)
		{
			Die();
			PlayerManager.Find(info.Sender).GetKill();
		}
	}

	void Die()
	{
		enemyManager.Die();
	}
}