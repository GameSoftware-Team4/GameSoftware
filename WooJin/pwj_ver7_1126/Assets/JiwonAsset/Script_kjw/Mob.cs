using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    public float curHealth = 100;
    public float damage = 3f;
    Enemy enemy;
    float delay = 2f;
    float delay_speed = 0.5f;
    private bool isDead = false;

    public GameObject expBall;
    GameManagerScript_pwj gameManager;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        enemy = GetComponent<Enemy>();
        expBall = Resources.Load<GameObject>("pwj_prefab/Exp");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Book")
        {
            BookSkill_jhj book = other.GetComponent<BookSkill_jhj>();
            curHealth -= book.b_damage_jhj;
            StartCoroutine(OnDamage());
        }
    }
        
    public void OngreDamage(float damage)
    {
        curHealth -= damage;
        Debug.Log("?? ??????");
        StartCoroutine(OnDamage());
    }

    public void OnexpDamaged(float damage)
    {
        curHealth -= damage;
        StartCoroutine(OnDamage());
    }
    public void OnIceDamaged(float damage, float d)
    {
        curHealth -= damage;
        delay -= d;
        StartCoroutine(OnIceDamage());
    }

    public void OnrocketDamage(float damage)
    {
        curHealth -= damage;
        StartCoroutine(OnDamage());
    }


    public void Damage(int damage, Vector3 _targetPos) //?? ??? ??
    {
        if (!isDead)
        {
            curHealth -= damage;
            StartCoroutine(OnDamage());

        }
    }

    IEnumerator OnDamage()
    {
        mat.color = Color.blue;
        yield return new WaitForSeconds(0.1f);
        
        if(curHealth > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            mat.color = Color.gray;
            enemy.DieAnim();
            Die();
            Destroy(gameObject, 1);
        }
    }

    IEnumerator OnIceDamage()
    {
        mat.color = Color.blue;
        enemy.SpeedChange(delay_speed);
        yield return new WaitForSeconds(delay);

        if (curHealth > 0)
        {
            mat.color = Color.white;
            enemy.SpeedChange(3.5f);
        }
        else
        {
            mat.color = Color.gray;
            enemy.DieAnim();
            Die();
            Destroy(gameObject, 1);
        }
    }
    public void OnTurretDamage(float damage, Vector3 _targetPos) //?? ??? ??
    {
        if (!isDead)
        {
            curHealth -= damage;
            StartCoroutine(OnDamage());

        }
    }

    void Die()
    {
        Instantiate(expBall, transform.position, transform.rotation);
        SpawningPool_jhj s_jhj = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        if (s_jhj != null) { s_jhj.DestroyMonster(); }

    }
}
