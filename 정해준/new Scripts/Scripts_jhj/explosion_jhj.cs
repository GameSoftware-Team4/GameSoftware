using UnityEngine;
using System.Collections;

public class explosion_jhj : MonoBehaviour
{
    float ep_damage_jhj = 50;
    Mob_jhj target_jhj;
    public GameObject skillEffect_jhj;
    GameObject player_jhj;
    float ep_radius = 5f;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Instantiate(skillEffect_jhj, player_jhj.transform);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            target_jhj = hitColliders_jhj[i].gameObject.GetComponent<Mob_jhj>(); //타겟들이 몬스터를 계승하는지 검거
            if(target_jhj != null) // 몬스터들만을 검거
            {


                target_jhj.OnDamage(ep_damage_jhj);

                Debug.Log("폭발!! " + ep_damage_jhj + "데미지!!");
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

