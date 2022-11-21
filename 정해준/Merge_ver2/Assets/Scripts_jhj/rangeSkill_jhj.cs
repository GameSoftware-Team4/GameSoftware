using UnityEngine;
using System.Collections;

public class rangeSkill_jhj : MonoBehaviour
{
    float damage_jhj = 50;
    Mob mob;
    public GameObject skillEffect_jhj;
    GameObject player_jhj;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Instantiate(skillEffect_jhj, player_jhj.transform);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Mob_jhj>(); //Ÿ�ٵ��� ���͸� ����ϴ��� �˰�
            if(target_jhj.tag != null) // ���͵鸸�� �˰�
            {


                target_jhj.OnDamage(damage_jhj);
                
                Debug.Log(damage_jhj);
            }
            i++;

        }
        
    }


   void Start()
    {
        player_jhj = GameObject.Find("Player");
        ExplosionDamage(player_jhj.transform.position, 5f);

    }
}

