using UnityEngine;
using System.Collections;

public class Tanohs : MonoBehaviour
{
    float damage_jhj = 50;
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
            if(hitColliders_jhj[i].tag == "Monster") // ���͵鸸�� �˰�
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OnexpDamaged(damage_jhj);

                Debug.Log("����!! " + damage_jhj + "������!!");
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

