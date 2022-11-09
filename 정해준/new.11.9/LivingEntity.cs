using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    //����ü�� ������ ���� ������Ʈ�� ����
    //ü��, ���ع���, ��� ���

    public float starting_hp = 100f; //���� ü��
    public float hp { get; protected set; } //���� ü��
    public bool dead { get; protected set; } //��� ����
    SpawningPool s;

    public event Action onDeath;//����� �ߵ��� �̺�Ʈ

    protected virtual void OnEnable() //����ü�� Ȱ��ȭ �� �� �ʱ�� ����
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
        Debug.Log("���!");
        s = GameObject.Find("SpawnManager").GetComponent<SpawningPool>();
        if (s != null) { s.DestroyMonster(); }
        Destroy(this.gameObject);
    }
}
