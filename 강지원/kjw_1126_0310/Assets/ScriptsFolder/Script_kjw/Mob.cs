using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rigid;
    BoxCollider boxCollider;
    Material mat;
    public float startHp = 100f;
    public float curHealth = 100f;
    public float damage = 3f;
    Enemy enemy;
    float delay = 2f;
    float delay_speed = 0.5f;
    public bool isDead = false;

    GameManagerScript_pwj gameManager;
    GameObject expcapsule;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        enemy = GetComponent<Enemy>();
        expcapsule = Resources.Load<GameObject>("pwj_prefab/Exp");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (!isDead)
        {
            if (other.tag == "Book")
            {
                BookSkill_jhj book = other.GetComponent<BookSkill_jhj>();
                curHealth -= book.b_damage_jhj;
                StartCoroutine(OnDamage());
            }
        }
    }

    public void OngreDamage(float damage)
    {
        if (!isDead)
        {
            curHealth -= damage;
            Debug.Log("?? ??????");
            StartCoroutine(OnDamage());
        }
    }

    public void OnexpDamaged(float damage)
    {
        if (!isDead)
        {
            curHealth -= damage;
            StartCoroutine(OnDamage());
        }
    }
    public void OnIceDamaged(float damage, float d)
    {
        if (!isDead)
        {
            curHealth -= damage;
            delay -= d;
            StartCoroutine(OnIceDamage());
        }
    }

    public void OnrocketDamage(float damage)
    {
        if (!isDead)
        {
            curHealth -= damage;
            StartCoroutine(OnDamage());
        }
    }


    public void Damage(int damage, Vector3 _targetPos) //?? ??? ??
    {
        if (!isDead)
        {
            curHealth -= damage;
            StartCoroutine(OnDamage());

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


    IEnumerator OnDamage()
    {
        mat.color = Color.blue;
        yield return new WaitForSeconds(0.1f);

        if(!isDead)
        { 
            if (curHealth > 0)
            {
                mat.color = Color.white;
            }
            else
            {
                mat.color = Color.gray;
                enemy.DieAnim();
                Die();
                Invoke("DestroyMob", 1f);
            }
        }
    }

    IEnumerator OnIceDamage()
    {
        mat.color = Color.blue;
        enemy.SpeedChange(delay_speed);
        yield return new WaitForSeconds(delay);

        if (!isDead)
        {
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
                Invoke("DestroyMob", 1f);
            }
        }
    }
    private void DestroyMob()
    {
        Debug.Log("파괴!");
        mat.color = Color.white;
        ObjectPool_jhj.ReturnObject(this);
        isDead = false;
        gameObject.tag = "Monster";
        curHealth = startHp;
        gameObject.layer = 8;

    }

    void Die()
    {
        isDead = true;
        gameObject.tag = "Untagged";
        gameObject.layer = 0;
        Debug.Log("Monster Die");
        Instantiate(expcapsule, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);

        SpawningPool_jhj s_jhj = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        if (s_jhj != null) { s_jhj.DestroyMonster(); }

        
    }
}