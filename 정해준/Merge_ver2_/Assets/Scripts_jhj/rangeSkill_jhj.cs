using UnityEngine;
using System.Collections;

public class rangeSkill_jhj : MonoBehaviour
{
    float damage_jhj = 50;
    Monster_jhj target_jhj;
    public GameObject skillEffect_jhj;
    GameObject player_jhj;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Instantiate(skillEffect_jhj, player_jhj.transform);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Monster_jhj>(); //Ÿ�ٵ��� ���͸� ����ϴ��� �˰�
            if(target_jhj != null) // ���͵鸸�� �˰�
            {

                
                
                Debug.Log("��ų");
                

                target_jhj.OnDamage(damage_jhj);
                
                Debug.Log(damage_jhj);
            }
            i++;

        }
        
    }

    /*IEnumerator WaitForIt()

    {
        Debug.Log("����");
        yield return new WaitForSeconds(0.f);

    }*/

   void Start()
    {
        player_jhj = GameObject.Find("Player");
        ExplosionDamage(player_jhj.transform.position, 5f);

    }
}

