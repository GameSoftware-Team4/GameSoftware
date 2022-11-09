using UnityEngine;
using System.Collections;

public class rangeSkill : MonoBehaviour
{
    float damage = 10;
    Monster target;
    public GameObject skillEffect;
    void ExplosionDamage(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            
            target = hitColliders[i].gameObject.GetComponent<Monster>();
            if(target != null)
            {
                target.OnDamage(damage);
                Debug.Log(damage);
                Instantiate(skillEffect, target.gameObject.transform);
            }
            i++;

        }
    }

    void Start()
    {
        ExplosionDamage(this.transform.position, 5f);
        ExplosionDamage(this.transform.position, 5f);
    }
}

