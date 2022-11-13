using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity_jhj : MonoBehaviour
{
    //����ü�� ������ ���� ������Ʈ�� ����
    //ü��, ���ع���, ��� ���

    public float starting_hp_jhj = 100f; //���� ü��
    public float hp_jhj { get; protected set; } //���� ü��
    public bool dead_jhj { get; protected set; } //��� ����
    SpawningPool_jhj s_jhj;

    public event Action onDeath;//����� �ߵ��� �̺�Ʈ

    protected virtual void OnEnable() //����ü�� Ȱ��ȭ �� �� �ʱ�� ����
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
        Debug.Log("���!");
        s_jhj = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        if (s_jhj != null) { s_jhj.DestroyMonster(); }
        Destroy(this.gameObject);
    }
}
