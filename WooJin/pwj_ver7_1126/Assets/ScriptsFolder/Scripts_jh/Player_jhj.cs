using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player_jhj : MonoBehaviour
{
    //생명체로 동작할 게임 오브젝트의 뼈대
    //체력, 피해받음, 사망 기능

    public float p_starting_hp_jhj = 100f; //시작 체력
    public float p_hp_jhj; //현재 체력
    public bool p_dead_jhj; //사망 상태
       
    

    public event Action onDeath;//사망시 발동할 이벤트

    protected void OnEnable() //생명체가 활성화 될 때 초기로 리셋
    {
        p_dead_jhj = false;

        p_hp_jhj = p_starting_hp_jhj;

    }



    public void OnDamage(float damage) //데미지 함수
    {
        //Debug.Log("남은 체력" + p_hp_jhj);
        p_hp_jhj -= damage;
        //Debug.Log("남은 체력" + p_hp_jhj);
        if(p_hp_jhj <= 0 && !p_dead_jhj)
        {
            Die();
        }
    }

    public void Die()
    {
        if(onDeath != null)
        {
            onDeath();
        }

        p_dead_jhj = true;
        
        
        
        Destroy(this.gameObject);
        Debug.Log("사망");
    }
}
