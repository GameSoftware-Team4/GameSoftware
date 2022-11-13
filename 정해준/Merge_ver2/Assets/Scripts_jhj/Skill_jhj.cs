using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_jhj : MonoBehaviour
{
    
 
    float damage_jhj = 15;
    Monster_jhj target_jhj; //스킬의 타겟은 오로지 몬스터 뿐

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {

                target_jhj = other.gameObject.GetComponent<Monster_jhj>();
                if (target_jhj != null)
                {
                
                    target_jhj.OnDamage(damage_jhj);
                    Debug.Log(damage_jhj + "데미지!");
                }
        
    }

    void OnCollisionEnter(Collision other)
    {


        target_jhj = other.gameObject.GetComponent<Monster_jhj>();
        if (target_jhj != null)
        {

            target_jhj.OnDamage(damage_jhj);
            Debug.Log(damage_jhj + "데미지!");
        }
    }

}
