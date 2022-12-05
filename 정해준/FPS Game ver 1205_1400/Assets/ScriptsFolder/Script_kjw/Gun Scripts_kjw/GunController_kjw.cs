using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController_kjw : MonoBehaviour
{
    [SerializeField]
    private Gun_kjw currentGun; // 현재 들고 있는 총. 📜Gun.cs 가 할당 됨.

    private float currentFireRate; // 이 값이 0 보다 큰 동안에는 총알이 발사 되지 않는다. 초기값은 연사 속도인 📜Gun.cs의 fireRate 

    private bool isReload = false;  // 재장전 중인지.

    private RaycastHit hitInfo;  // 총알의 충돌 정보

    [SerializeField]
    private Camera theCam;  // 카메라 시점에서 정 중앙에 발사할 거라서

    private bool isFineSightMode = false;

    [SerializeField]
    private Vector3 originPos;  // 원래 총의 위치(정조준 해제하면 나중에 돌아와야 하니까)

    private AudioSource audioSource;  // 발사 소리 재생기

    int layerMask;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        layerMask = 1 << LayerMask.NameToLayer("Monster");
    }

    void Update()
    {
        GunFireRateCalc();
        TryFire();
        TryReload();
    }

    private void GunFireRateCalc()
    {
        if (currentFireRate > 0)
            currentFireRate -= Time.deltaTime;  // 즉, 1 초에 1 씩 감소시킨다.
    }

    private void TryFire()  // 발사 입력을 받음
    {
        if (Input.GetButton("Fire1") && currentFireRate <= 0 && !isReload)
        {
            Fire();
        }
    }

    private void Fire()  // 발사를 위한 과정
    {
        if (!isReload)
        {
            if (currentGun.currentBulletCount > 0)
                Shoot();
            else
            {
                StartCoroutine(ReloadCoroutine());
            }
        }
    }

    private void Shoot()  // 실제 발사 되는 과정
    {
        currentGun.currentBulletCount--;
        currentFireRate = currentGun.fireRate;  // 연사 속도 재계산
        PlaySE(currentGun.fire_Sound);
        currentGun.anim.SetTrigger("Shoot");
        currentGun.anim.SetTrigger("Idle");
        currentGun.muzzleFlash.Play();

        // 피격 처리
        Hit();


        // 총기 반동 코루틴 실행
        StopAllCoroutines();
        StartCoroutine(RetroActionCoroutine());

        Debug.Log("총알 발사 함");
    }

    private void Hit()
    {
        // 카메라 월드 좌표!! (localPosition이 아님)
        if (Physics.Raycast(theCam.transform.position, theCam.transform.forward, out hitInfo, currentGun.range, layerMask))
        {
            Debug.Log(hitInfo.transform.name);
           
            hitInfo.transform.GetComponent<Mob>().Damage(currentGun.damage, transform.position);
            
        }
    }

        

    private void TryReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReload && currentGun.currentBulletCount < currentGun.reloadBulletCount)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }

    IEnumerator ReloadCoroutine()
    {
        if (currentGun.carryBulletCount > 0)
        {
            isReload = true;
            currentGun.anim.SetTrigger("Reload");
             
            currentGun.carryBulletCount += currentGun.currentBulletCount;
            currentGun.currentBulletCount = 0;

            yield return new WaitForSeconds(currentGun.reloadTime);  // 재장전 애니메이션이 다 재생될 동안 대기

            if (currentGun.carryBulletCount >= currentGun.reloadBulletCount)
            {
                currentGun.currentBulletCount = currentGun.reloadBulletCount;
                currentGun.carryBulletCount -= currentGun.reloadBulletCount;
            }
            else
            {
                currentGun.currentBulletCount = currentGun.carryBulletCount;
                currentGun.carryBulletCount = 0;
            }

            isReload = false;
        }
        else
        {
            Debug.Log("소유한 총알이 없습니다.");
        }
    }

    public Gun_kjw GetGun()
    {
        return currentGun;
    }




    IEnumerator RetroActionCoroutine()
    {
        Vector3 recoilBack = new Vector3(currentGun.retroActionForce, originPos.y, originPos.z);     // 정조준 안 했을 때의 최대 반동
       
        if (!isFineSightMode)  // 정조준이 아닌 상태
        {
            // 반동 시작
            while (currentGun.transform.localPosition.x <= currentGun.retroActionForce - 0.02f)
            {
                currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, recoilBack, 0.4f);
                yield return null;
            }

            // 원위치
            while (currentGun.transform.localPosition != originPos)
            {
                currentGun.transform.localPosition = Vector3.Lerp(currentGun.transform.localPosition, originPos, 0.1f);
                yield return null;
            }
        }
        

    }

    private void PlaySE(AudioClip _clip)  // 발사 소리 재생
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }
}
