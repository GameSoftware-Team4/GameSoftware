using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    SpawningPool s;
    // Start is called before the first frame update
    void Start()
    {
        s = GameObject.Find("SpawnManager").GetComponent<SpawningPool>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnCollisionEnter(Collision other)
    {
        if (s != null)
        {
            s.DestroyMonster();
            Destroy(other.gameObject);
        }
        
    }*/
}
