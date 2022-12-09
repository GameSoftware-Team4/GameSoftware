using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSkill_jhj : MonoBehaviour
{
    
 
    public float b_damage_jhj = 30;
    //Mob_jhj target_jhj; //스킬의 타겟은 오로지 몬스터 뿐
    //float scalespeed_jhj = 1f; 

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {


        //target_jhj = other.gameObject.GetComponent<Mob_jhj>();
        if (other.gameObject.tag == "Monster")
        {

            //target_jhj.OnDamage(b_damage_jhj);
            
        }
    }
    public void BookLevelup()
    {
        
        b_damage_jhj += 5;

    }
}
