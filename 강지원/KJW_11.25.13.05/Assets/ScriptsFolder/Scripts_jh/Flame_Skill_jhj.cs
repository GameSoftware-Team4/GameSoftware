using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame_Skill_jhj : MonoBehaviour
{


    float damage_jhj = 18;
    Mob target_jhj; //��ų�� Ÿ���� ������ ���� ��


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnParticleCollision(GameObject other)
    {

        target_jhj = other.gameObject.GetComponent<Mob>();
        if (target_jhj != null)
        {

            //target_jhj.OnDamage(damage_jhj);
            Debug.Log(damage_jhj + "������!");
        }

    }

    void OnCollisionEnter(Collision other)
    {


        target_jhj = other.gameObject.GetComponent<Mob>();
        if (target_jhj != null)
        {

            //target_jhj.OnDamage(damage_jhj);
            Debug.Log(damage_jhj + "������!");
        }
    }

}
