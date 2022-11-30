using UnityEngine;
using System.Collections;

public class ice : MonoBehaviour
{
    float ice_damage_jhj = 20;
    public GameObject iceEffect_jhj;
    public float ep_radius = 20f;

    void IceDamage(Vector3 center, float radius)
    {
        Instantiate(iceEffect_jhj, this.gameObject.transform);
        Collider[] hitColliders_jhj = Physics.OverlapSphere(center, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
        while (i < hitColliders_jhj.Length)
        {

            if (hitColliders_jhj[i].tag == "Monster") // 몬스터들만을 검거
            {

                Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                m.OnIceDamaged(ice_damage_jhj, 2f);

                Debug.Log("얼음!! " + ice_damage_jhj + "데미지!!");
            }
            i++;

        }

    }


    void Start()
    {
        iceEffect_jhj = Resources.Load<GameObject>("prefabs_jhj/ice_eff");
        IceDamage(this.gameObject.transform.position, ep_radius);

    }
}

