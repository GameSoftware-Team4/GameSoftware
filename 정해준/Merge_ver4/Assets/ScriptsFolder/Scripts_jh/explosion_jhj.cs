using UnityEngine;
using System.Collections;

public class explosion_jhj : MonoBehaviour
{
    float ep_damage_jhj = 50;
    Mob target_jhj;
    public GameObject skillEffect_jhj;
    GameObject player_jhj;
    float ep_radius = 10f;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Instantiate(skillEffect_jhj, player_jhj.transform);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            //target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Mob_jhj>(); //Ÿ�ٵ��� ���͸� ����ϴ��� �˰�
            if(hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
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
        player_jhj = GameObject.Find("Player");
        ExplosionDamage(player_jhj.transform.position, ep_radius);

    }
}

