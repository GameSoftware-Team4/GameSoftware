using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    
 
    float damage_jhj = 15;
    Monster target_jhj; //��ų�� Ÿ���� ������ ���� ��

    
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




                target_jhj = other.gameObject.GetComponent<Monster>();
                if (target_jhj != null)
                {
                
                    target_jhj.OnDamage(damage_jhj);
                    Debug.Log(damage_jhj + "������!");
                }
        
    }

}
