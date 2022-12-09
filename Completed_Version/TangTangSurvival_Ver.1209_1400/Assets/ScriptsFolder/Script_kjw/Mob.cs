using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
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
    PhotonView PV;

    public AudioClip clip;
    AudioSource sunset;

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
        PV = GetComponent<PhotonView>();

        sunset = GetComponent<AudioSource>();
        sunset.clip = clip;
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
            }
        }
    }

    public void OngreDamage(float damage)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
        }
    }

    public void OnexpDamaged(float damage)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
        }
    }

    public void OnIceDamaged(float damage, float d)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
            delay -= d;
        }
    }

    public void OnrocketDamage(float damage)
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
        }
    }


    public void Damage(float damage, Vector3 _targetPos) //?? ??? ??
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);

        }
    }

    public void OnTurretDamage(float damage, Vector3 _targetPos) //?? ??? ??
    {
        if (isDead == false)
        {
            photonView.RPC("OnDamageRPC", RpcTarget.All, damage);
        }
    }

    [PunRPC]
    public void OnDamageRPC(float _damage)
    {
        StartCoroutine(OnDamage(_damage));
    }

    IEnumerator OnDamage(float _damage)
    {
        curHealth -= _damage;
        mat.color = Color.blue;
        photonView.RPC("PlayAudio", RpcTarget.All);
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
            Debug.Log("Die");
            Invoke("DestroyMob", 1f);
        }
    }

    IEnumerator OnIceDamage()
    {
        mat.color = Color.blue;
        photonView.RPC("PlayAudio", RpcTarget.All);
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
        if(PV.IsMine)
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }

    [PunRPC]
    void PlayAudio()
    {

        sunset.Play();
    }

    void Die()
    {
        gameObject.tag = "Untagged";
        gameObject.layer = 0;

        EnemyManager enemyManager = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
        if (enemyManager != null) { enemyManager.DestroyMonster(); }
        GameObject exp = PhotonNetwork.Instantiate(Path.Combine("pwj_prefab", "Exp"), gameObject.transform.position, gameObject.transform.rotation);
        //gameManager = GameObject.Find("Canvas").GetComponent<GameManagerScript_pwj>();
        // if (gameManager != null) { gameManager.SetExp(); }
    }
}
