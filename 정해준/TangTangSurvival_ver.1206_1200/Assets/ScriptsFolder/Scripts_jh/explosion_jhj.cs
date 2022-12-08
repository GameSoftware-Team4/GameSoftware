using UnityEngine;
using System.Collections;

public class explosion_jhj : MonoBehaviour
{
    float ep_damage_jhj = 70;
    //GameObject player_jhj;
    float ep_radius = 10f;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {
            if (hitColliders_jhj[i].tag == "Monster") 
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OnexpDamaged(ep_damage_jhj);

                Debug.Log("����!! " + ep_damage_jhj + "������!!");
            }
            i++;

        }

    }


    void Start()
    {
        ExplosionDamage(gameObject.transform.position, ep_radius);

    }
}

