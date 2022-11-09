using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    
 
    float damage = 15;
    Monster target;

    
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
        
 

                
                target = other.gameObject.GetComponent<Monster>();
                
                if (target != null)
                {
                    target.OnDamage(damage);
                    Debug.Log(damage + "µ¥¹ÌÁö!");
                }
                    //s.DestroyMonster();
                    //Destroy(other.gameObject);
                    
                
            

        
    }

}
