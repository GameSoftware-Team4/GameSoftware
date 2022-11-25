using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob2 : MonoBehaviour
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

    GameManagerScript_pwj gameManager;

    
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        enemy = GetComponent<Enemy>();
  


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
        if(other.tag == "g_fire")
        {
            curHealth -= 10;
            Debug.Log("화염 데미지!");
            StartCoroutine(OnDamage());
        }
    }

    public void OngreDamage(float damage)
    {
        curHealth -= damage;
        Debug.Log("독 데미지");
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
            Die();
            //Invoke("DestroyMob", 1f);
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
            Die();
            //Invoke("DestroyMob", 1f);
        }
    }
    private void DestroyMob()
    {
        Debug.Log("파괴!");
        mat.color = Color.white;
        //ObjectPool_jhj.ReturnObject(this);
    }

    void Die()
    {
        SpawningPool_jhj s_jhj = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        if (s_jhj != null) { s_jhj.DestroyMonster(); }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript_pwj>();
        if (gameManager != null) { gameManager.SetExp(); }
    }
}
