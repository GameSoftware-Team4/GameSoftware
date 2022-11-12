using UnityEngine;
using System.Collections;

public class rangeSkill_jhj : MonoBehaviour
{
    float damage_jhj = 50;
    Monster_jhj target_jhj;
    public GameObject skillEffect_jhj;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Instantiate(skillEffect_jhj, this.transform);
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

    IEnumerator WaitForIt()

    {
        Debug.Log("����");
        yield return new WaitForSeconds(1.0f);

    }

    void Start()
    {
        ExplosionDamage(this.transform.position, 5f);

    }
}

