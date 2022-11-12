using UnityEngine;
using System.Collections;

public class rangeSkill : MonoBehaviour
{
    float damage_jhj = 10;
    Monster target_jhj;
    public GameObject skillEffect_jhj;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // ������ ���ȿ� �ִ� ������Ʈ�� �˰�
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Monster>(); //Ÿ�ٵ��� ���͸� ����ϴ��� �˰�
            if(target_jhj != null) // ���͵鸸�� �˰�
            {
                target_jhj.OnDamage(damage_jhj);
                Debug.Log(damage_jhj);
                Instantiate(skillEffect_jhj, target_jhj.gameObject.transform);
            }
            i++;

        }
    }

    void Start()
    {
        ExplosionDamage(this.transform.position, 5f);
        ExplosionDamage(this.transform.position, 5f);
    }
}

