using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviourPunCallbacks
{
    //목적지
    public Transform target;
    //요원
    NavMeshAgent agent;
    public float enemy_speed = 3.5f;
    public Animator anim;
    public Mob mob;

    //열거형으로 정해진 상태값을 사용
    enum State
    {
        Idle,
        Run,
        Die
    }
    //상태 처리
    State state;

    // Start is called before the first frame update
    void Start()
    {
        //생성시 상태를 Idle로 한다.
        state = State.Idle;

        //요원을 정의해줘서
        agent = GetComponent<NavMeshAgent>();
        target = null;
        mob = GetComponent<Mob>();
    }

    // Update is called once per frame
    void Update()
    {
        //생성될때 목적지(Player)를 찿는다.
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Player");
        //target을 찾으면 Run상태로 전이하고 싶다.
        foreach (GameObject tg in targets)
        {
            if (target == null || Vector3.Distance(tg.transform.position, transform.position) < Vector3.Distance(target.transform.position, transform.position))
            {
                target = tg.transform;
            }
        }
        //만약 state가 idle이라면
        if (state == State.Idle)
        {
            UpdateIdle();
        }
        else if (state == State.Run)
        {
            UpdateRun();
        }

    }
    //사망시 애니메이션 재생
    [PunRPC]
    public void DieAnim()
    {
        anim.SetTrigger("Die");
    }
        
    private void UpdateRun()
    {
        if (mob.isDead == false)
        {
            //타겟 방향으로 이동하다가
            agent.speed = enemy_speed;
            //요원에게 목적지를 알려준다.
            agent.destination = target.transform.position;
        }
        else
        {
            state = State.Idle;
        }
    }

    private void UpdateIdle()
    {
        agent.speed = 0;
        if (mob.isDead == false)
        {
            if (target != null)
            {
                state = State.Run;
                //이렇게 state값을 바꿨다고 animation까지 바뀔까? no! 동기화를 해줘야한다.
                anim.SetTrigger("Run");
            }
        }
    }
    public void SpeedChange(float new_speed)
    {
        enemy_speed = new_speed;
        Debug.Log("속도" + enemy_speed);
    }

    public override void OnPlayerLeftRoom(Player LeftPlayer)
    {
        target = null;
        state = State.Idle;
    }
}
