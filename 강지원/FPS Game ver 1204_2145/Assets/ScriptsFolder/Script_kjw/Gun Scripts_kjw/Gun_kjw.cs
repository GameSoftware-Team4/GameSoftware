using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_kjw : MonoBehaviour
{
    /* 모든 종류의 총들이 공통적으로 갖고 있는 속성들(멤버 변수들) */

    public string gunName;  // 총의 이름. 총의 종류가 여러개이기 때문에.
    public float range;     // 총의 사정 거리. 총마다 사정 거리 다름. 총알이 너무 멀리까지 영원히 날아가면 안되니까.
    public float accuracy;  // 총의 정확도. 총의 종류마다 정확도가 다름.
    public float fireRate;  // 연사 속도. 즉 한발과 한발간의 시간 텀. 높으면 높을 수록 연사가 느려짐. 총의 종류마다 다름.
    public float reloadTime;// 재장전 속도. 총의 종류마다 다름.

    public float damage;      // 총의 공격력. 총의 종류마다 다름.

    public int reloadBulletCount;   // 총의 재장전 개수. 재장전 할 때 몇 발씩 될지. 총의 종류마다 다름.
    public int currentBulletCount;  // 현재 탄창에 남아있는 총알의 개수.
    public int maxBulletCount;      // 총알을 최대 몇 개까지 소유할 수 있는지. 
    public int carryBulletCount;    // 현재 소유하고 있는 총알의 총 개수.

    public float retroActionForce;  // 반동 세기. 총의 종류마다 다름.

    public Animator anim;   // 총의 애니메이션을 재생할 애니메이터 컴포넌트
    public ParticleSystem muzzleFlash;  // 화염구 이펙트 재생을 담당할 파티클 시스템 컴포넌트
    public AudioClip fire_Sound;    // 총 발사 소리 오디오 클립

}
