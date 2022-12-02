using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

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
    public bool isDead;
    public PhotonView photonView;

    GameManagerScript_pwj gameManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        enemy = GetComponent<Enemy>();
        this.gameObject.SetActive(true);
        gameObject.tag = "Monster";
        gameObject.layer = 7;
        isDead = false;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Book")
        {
            if (isDead == false)
            {
                BookSkill_jhj book = other.GetComponent<BookSkill_jhj>();
                photonView.RPC("OnDamageRPC", RpcTarget.All, book.b_damage_jhj);
                StartCoroutine(OnDamage());
            }
        }
    }

    public void OngreDamage(float damage)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            Debug.Log("?? ??????");
            StartCoroutine(OnDamage());
        }
    }

    public void OnexpDamaged(float damage)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            StartCoroutine(OnDamage());
        }
    }

    public void OnIceDamaged(float damage, float d)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            delay -= d;
            StartCoroutine(OnIceDamage());
        }
    }

    public void OnrocketDamage(float damage)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            StartCoroutine(OnDamage());
        }
    }


    public void Damage(float damage, Vector3 _targetPos) //?? ??? ??
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            StartCoroutine(OnDamage());

        }
    }

    public void OnTurretDamage(float damage, Vector3 _targetPos) //?? ??? ??
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            StartCoroutine(OnDamage());

        }
    }

    [PunRPC]
    public void OnDamageRPC(float _damage)
    {
        curHealth -= _damage;
    }

    IEnumerator OnDamage()
    {
        mat.color = Color.blue;
        yield return new WaitForSeconds(0.1f);

        if (curHealth > 0)
        {
            mat.color = Color.white;
        }
        else
        {
            isDead = true;
            mat.color = Color.gray;
            enemy.DieAnim();
            Die();
            Invoke("DestroyMob", 1f);
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
            isDead = true;
            mat.color = Color.gray;
            enemy.DieAnim();
            Die();
            Invoke("DestroyMob", 1f);
        }
    }
    private void DestroyMob()
    {
        Debug.Log("파괴!");
        mat.color = Color.white;
        PhotonNetwork.Destroy(this.GetComponent<PhotonView>());
    }

    void Die()
    {
        gameObject.tag = "Untagged";
        gameObject.layer = 0;

        EnemyManager enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        if (enemyManager != null) { enemyManager.DestroyMonster(); }

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript_pwj>();
        if (gameManager != null) { gameManager.SetExp(); }
    }
}
