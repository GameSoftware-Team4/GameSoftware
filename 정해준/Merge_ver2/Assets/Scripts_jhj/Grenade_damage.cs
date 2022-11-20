using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_damage : MonoBehaviour
{
    
 
    
    float p_damage_jhj = 20;
    public float radius = 10f;
    public float delay = 0;

    // Start is called before the first frame update
    void Start()
    {
            Collider[] hitColliders_jhj = Physics.OverlapSphere(transform.position, radius); // 지정한 구안에 있는 오브젝트를 검거
            int i = 0;
            while (i < hitColliders_jhj.Length)
            {

                if (hitColliders_jhj[i].tag == "Monster") // 몬스터들만을 검거
                {

                    Mob m = hitColliders_jhj[i].GetComponent<Mob>();
                    m.OngreDamage(p_damage_jhj);

                    Debug.Log("독" + p_damage_jhj + "데미지!!");
                }
                i++;

            }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrenadeLevelup()
    {
        
        p_damage_jhj += 5;

    }
}
