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
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Mob_jhj>(); //타겟들이 몬스터를 계승하는지 검거
            if(target_jhj.tag != null) // 몬스터들만을 검거
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

