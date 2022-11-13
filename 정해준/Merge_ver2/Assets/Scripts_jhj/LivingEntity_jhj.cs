using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity_jhj : MonoBehaviour
{
    //생명체로 동작할 게임 오브젝트의 뼈대
    //체력, 피해받음, 사망 기능

    public float starting_hp_jhj = 100f; //시작 체력
    public float hp_jhj { get; protected set; } //현재 체력
    public bool dead_jhj { get; protected set; } //사망 상태
    SpawningPool_jhj s_jhj;

    public event Action onDeath;//사망시 발동할 이벤트

    protected virtual void OnEnable() //생명체가 활성화 될 때 초기로 리셋
    {
        dead_jhj = false;

        hp_jhj = starting_hp_jhj;

    }

    public virtual void OnDamage(float damage)
    {
        hp_jhj -= damage;
        Debug.Log(hp_jhj);
        if(hp_jhj <= 0 && !dead_jhj)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }

        dead_jhj = true;
        Debug.Log("사망!");
        s_jhj = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        if (s_jhj != null) { s_jhj.DestroyMonster(); }
        Destroy(this.gameObject);
    }
}
