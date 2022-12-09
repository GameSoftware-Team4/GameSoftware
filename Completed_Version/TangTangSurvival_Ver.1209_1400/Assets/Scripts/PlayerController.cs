using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerController : MonoBehaviourPunCallbacks, IDamageable
{
	[SerializeField] Image healthbarImage;
	[SerializeField] GameObject ui;

	[SerializeField] GameObject cameraHolder;

	[SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;

	[SerializeField] Item[] items;

	int itemIndex;
	int previousItemIndex = -1;
	public Skill_set skill_set;
	float verticalLookRotation;
	bool grounded;
	Vector3 smoothMoveVelocity;
	Vector3 moveAmount;
	public AudioClip clip;
	AudioSource sunset;

	bool damage_trigger;

	Rigidbody rb;

	PhotonView PV;

	public float maxHealth = 100f;
	public float currentHealth;

	PlayerManager playerManager;

	void Awake()
	{
		maxHealth = 100f;
		currentHealth = maxHealth;
		Debug.Log(gameObject.transform.position);
		rb = GetComponent<Rigidbody>();
		PV = GetComponent<PhotonView>();
		/*skill_set = GameObject.Find("skill_sets").GetComponent<Skill_set>();*/
		/*skill_set = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<Skill_set>();*/
		playerManager = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<PlayerManager>();
		sunset = GetComponent<AudioSource>();
		sunset.clip = clip;
		damage_trigger = true;
		// 게임 화면 내 커서 숨기는 코드
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Start()
	{
		if(PV.IsMine)
		{
			return;
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

		Look();
		Move();
		Jump();

		if(transform.position.y < -10f) // Die if you fall out of the world
		{
			Die();
		}
	}

	void Look()
	{
		transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

		verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

		cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
	}

	void Move()
	{
		Vector3 moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

		moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
	}

	void Jump()
	{
		if(Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			rb.AddForce(transform.up * jumpForce);
		}
	}

	public void SetGroundedState(bool _grounded)
	{
		grounded = _grounded;
	}

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

		healthbarImage.fillAmount = currentHealth / maxHealth;

		if(currentHealth <= 0)
		{
			Die();
			PlayerManager.Find(info.Sender).GetKill();
		}
	}
	void OnCollisionEnter(Collision other) //데미지 받았을 때
	{
		if (other.gameObject.tag == "Monster" && damage_trigger)
		{
			Mob m = other.gameObject.GetComponent<Mob>();
			TakeDamage(m.damage);
			if(gameObject.activeSelf == true)
			{
				photonView.RPC("PlayAudio", RpcTarget.All);
				StartCoroutine("DamageOff");
			}
		}
	}

	IEnumerator DamageOff()
    {
		damage_trigger = false;
		// Debug.Log("무적");
		yield return new WaitForSeconds(1f);
		damage_trigger = true;
		// Debug.Log("무적 끝");
    }

	[PunRPC]
	void PlayAudio()
	{

		sunset.Play();
	}

	void Die()
	{
		playerManager.Die();
	}
}