using UnityEngine;
using System.Collections;

public class rangeSkill : MonoBehaviour
{
    float damage_jhj = 10;
    Monster target_jhj;
    public GameObject skillEffect_jhj;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Monster>(); //타겟들이 몬스터를 계승하는지 검거
            if(target_jhj != null) // 몬스터들만을 검거
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

