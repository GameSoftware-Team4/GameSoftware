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
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Monster_jhj>(); //타겟들이 몬스터를 계승하는지 검거
            if(target_jhj != null) // 몬스터들만을 검거
            {

                
                
                Debug.Log("스킬");
                

                target_jhj.OnDamage(damage_jhj);
                
                Debug.Log(damage_jhj);
            }
            i++;

        }
    }

    IEnumerator WaitForIt()

    {
        Debug.Log("지연");
        yield return new WaitForSeconds(1.0f);

    }

    void Start()
    {
        ExplosionDamage(this.transform.position, 5f);

    }
}

