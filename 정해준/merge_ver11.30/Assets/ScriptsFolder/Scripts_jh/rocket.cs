using UnityEngine;
using System.Collections;

public class rocket : MonoBehaviour
{
    float r_damage_jhj = 50;
    Mob target_jhj;
    public float radius = 1f;
    void Start( ) 
    {
        Collider[] hitColliders_jhj = Physics.OverlapSphere(transform.position, radius); // 지정한 구안에 있는 오브젝트를 검거
        int i = 0;
            while (i<hitColliders_jhj.Length)
            {

                if (hitColliders_jhj[i].tag == "Monster") // 몬스터들만을 검거
                {

                    Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                    m.OnrocketDamage(r_damage_jhj);

                    Debug.Log("로켓" + r_damage_jhj + "데미지!!");
                }
                i++;

            }

        
    }
    
}

