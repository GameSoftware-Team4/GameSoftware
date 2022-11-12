using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    SpawningPool s;
    MonsterAI m;
    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("SpawnManager").GetComponent<SpawningPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("�浹");
        if (s != null)
        {
            m = other.gameObject.GetComponent<MonsterAI>();
            if(m != null && (Define.WorldObject.Monster == m.returnType()))
            {

                    Debug.Log("Monster");
                    s.DestroyMonster();
                    Destroy(other.gameObject);
                
            }

        }
    }

}
