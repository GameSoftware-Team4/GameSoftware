using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    //생명체로 동작할 게임 오브젝트의 뼈대
    //체력, 피해받음, 사망 기능

    public float starting_hp = 100f; //시작 체력
    public float hp { get; protected set; } //현재 체력
    public bool dead { get; protected set; } //사망 상태
    SpawningPool s;

    public event Action onDeath;//사망시 발동할 이벤트

    protected virtual void OnEnable() //생명체가 활성화 될 때 초기로 리셋
    {
        dead = false;

        hp = starting_hp;

    }

    public virtual void OnDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0 && !dead)
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

        dead = true;
        Debug.Log("사망!");
        s = GameObject.Find("SpawnManager").GetComponent<SpawningPool>();
        if (s != null) { s.DestroyMonster(); }
        Destroy(this.gameObject);
    }
}
