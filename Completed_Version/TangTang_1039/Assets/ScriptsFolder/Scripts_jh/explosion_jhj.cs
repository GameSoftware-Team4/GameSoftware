using UnityEngine;
using System.Collections;

public class explosion_jhj : MonoBehaviour
{
    float ep_damage_jhj = 70;
    //GameObject player_jhj;
    float ep_radius = 10f;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {
            if (hitColliders_jhj[i].tag == "Monster") 
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OnexpDamaged(ep_damage_jhj);

                // Debug.Log("폭발!! " + ep_damage_jhj + "데미지!!");
            }
            i++;

        }

    }


    void Start()
    {
        ExplosionDamage(gameObject.transform.position, ep_radius);

    }
}

