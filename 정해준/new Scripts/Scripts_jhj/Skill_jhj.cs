using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_jhj : MonoBehaviour
{
    
 
    float damage_jhj = 15;
    Mob_jhj target_jhj; //스킬의 타겟은 오로지 몬스터 뿐
    //float scalespeed_jhj = 1f; 

    
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

                target_jhj = other.gameObject.GetComponent<Mob_jhj>();
                if (target_jhj != null)
                {
                
                    target_jhj.OnDamage(damage_jhj);
                    
                }
        
    }

    void OnCollisionEnter(Collision other)
    {


        target_jhj = other.gameObject.GetComponent<Mob_jhj>();
        if (target_jhj != null)
        {

            target_jhj.OnDamage(damage_jhj);
            
        }
    }
    public void LevelupSkill()
    {
        Debug.Log("level up");
        damage_jhj += 5;

    }
}
