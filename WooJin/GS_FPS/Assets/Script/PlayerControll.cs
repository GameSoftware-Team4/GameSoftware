using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
	[SerializeField]
	private float walkSpeed = 15;
	[SerializeField]
	private float runSpeed = 30;
	private float applySpeed = 30;
	private float crouchSpeed = 7;

	private bool isRun = false;
	private bool isGround = true;
	private bool isCrouch = true;

	// 앉았을 때 얼마나 앉을지 결정하는 변수
	[SerializeField]
	private float crouchPosY;
	private float originPosY;
	private float applyCrouchPosY;

	// 땅 착지 여부
	private BoxCollider capsule;

	[SerializeField]
	private float jumpForce;

	[SerializeField]
	private float lookSensitivity = 5;

	[SerializeField]
	private float cameraRotationLimit = 90;
	private float currentCameraRotationX = 0;

	[SerializeField]
	private Camera theCamera;
	private Rigidbody myRigid;

	void Start()
	{
		capsule = GetComponent<BoxCollider>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		applySpeed = walkSpeed;
		myRigid = GetComponent<Rigidbody>();  // private
		originPosY = theCamera.transform.localPosition.y;
		applyCrouchPosY = originPosY;
	}

	void Update()  // 컴퓨터마다 다르지만 대략 1초에 60번 실행
	{
		IsGround();
		TryJump();
		TryRun();
		TryCrouch();
		Move();                 // 1?? 키보드 입력에 따라 이동
		CameraRotation();       // 2?? 마우스를 위아래(Y) 움직임에 따라 카메라 X 축 회전 
		CharacterRotation();    // 3?? 마우스 좌우(X) 움직임에 따라 캐릭터 Y 축 회전 
	}

	private void TryCrouch()
    {
		if (Input.GetKeyDown(KeyCode.LeftControl))
        {
			Crouch();
        }
    }

	private void Crouch()
    {
		isCrouch = !isCrouch;

        if (isCrouch)
        {
			applySpeed = crouchSpeed;
			applyCrouchPosY = crouchPosY;
        }
        else
        {
			applySpeed = walkSpeed;
			applyCrouchPosY = originPosY;
		}

		Debug.Log(applySpeed);

		StartCoroutine(CrouchCoroutine());
    }

	IEnumerator CrouchCoroutine()
    {
		float _posY = theCamera.transform.localPosition.y;
		int cnt = 0;
		while(_posY != applyCrouchPosY)
        {
			cnt++;
			_posY = Mathf.Lerp(_posY, applyCrouchPosY, 0.25f);
			theCamera.transform.localPosition = new Vector3(0, _posY, 0);
			if (cnt > 15)
				break;
			yield return null;
		}
		theCamera.transform.localPosition = new Vector3(0, applyCrouchPosY, 0);
    }

	private void IsGround()
    {
		isGround = Physics.Raycast(transform.position, Vector3.down, capsule.bounds.extents.y + 0.1f);

    }

	private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
			Jump();
        }
    }

	private void Jump()
    {
		if (isCrouch)
			Crouch();
		myRigid.velocity = transform.up * jumpForce;
    }
	private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
			Running();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
			RunningCancel();
        }
    }

	private void Running()
    {
		isRun = true;
		applySpeed = runSpeed;
    }

	private void RunningCancel()
    {
		isRun = false;
		applySpeed = walkSpeed;
    }

	private void Move()
	{
		float _moveDirX = Input.GetAxisRaw("Horizontal");
		float _moveDirZ = Input.GetAxisRaw("Vertical");
		Vector3 _moveHorizontal = transform.right * _moveDirX;
		Vector3 _moveVertical = transform.forward * _moveDirZ;

		Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

		myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
	}

	private void CameraRotation()
	{
		float _xRotation = Input.GetAxisRaw("Mouse Y");
		float _cameraRotationX = _xRotation * lookSensitivity;

		currentCameraRotationX -= _cameraRotationX;
		currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

		theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
	}

	private void CharacterRotation()  // 좌우 캐릭터 회전
	{
		float _yRotation = Input.GetAxisRaw("Mouse X");
		Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
		myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
	}
}