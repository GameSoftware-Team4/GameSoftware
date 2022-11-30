using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Player_jhj : MonoBehaviour
{
    //����ü�� ������ ���� ������Ʈ�� ����
    //ü��, ���ع���, ��� ���

    public float p_starting_hp_jhj = 100f; //���� ü��
    public float p_hp_jhj; //���� ü��
    public bool p_dead_jhj; //��� ����



    public event Action onDeath;//����� �ߵ��� �̺�Ʈ

    protected void OnEnable() //����ü�� Ȱ��ȭ �� �� �ʱ�� ����
    {
        p_dead_jhj = false;

        p_hp_jhj = p_starting_hp_jhj;

    }




    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Monster")
        {
            Mob m = other.gameObject.GetComponent<Mob>();
            p_hp_jhj -= m.damage;
            if (p_hp_jhj <= 0)
            {
                Die();
            }
        }
    }


    public void Die()
    {
        if (onDeath != null)
        {
            onDeath();
        }

        p_dead_jhj = true;



        Destroy(this.gameObject);
        Debug.Log("���");
    }
}
