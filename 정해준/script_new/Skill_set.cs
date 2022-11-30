using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_set : MonoBehaviour
{
    public GameObject[] skill_tree;
    public bool trigger_book;
    public bool trigger_ep;
    public bool trigger_ice;
    public bool trigger_gre;
    public bool trigger_ta;
    public bool tur_trigger;

    GameObject b_m; // bookmovement trigger
    bool trigger_6 = false;
    float cool_ep = 10f;  //폭발의 쿨타임
    float cool_ice = 10f;//아이스의 쿭타임
    float cool_gre = 5f;//수류탄의 쿨타임
    public GameObject firePosition; //수류탄의 던지는 위치;
    float throw_power = 7f; //수류탄을 던지는 힘

    //turret objects
    public GameObject turretPref;
    public Image w6Img;
    

    public float b_lv = 0;
    public float e_lv = 0;
    public float i_lv = 0;
    public float g_lv = 0;
    public float t_lv = 0;

    bool tri_book_move = false;

    //public Image w1Img;
    //public Image w2Img;
    //public Image w3Img;
    //public Image w4Img;
    //public Image w5Img;
    Vector3 fire = new Vector3(-0.03f, 1.46f, 0.81f);

    float b_yPosition_jsj = 0.7f;  //y축 위치

    float b_radius_jhj = 5.0f;   // 이동하는 반지름의 크기

    public float b_angularVelocity_jhj = 360.0f; //속도

    public float b_angle_jhj = 0.0f; //각도

    float b_degreePersecond_jhj = 200;  //주변을 돌 때 물체자체가 회전할 때 초당 움직이는 위치

    // Start is called before the first frame update
    void Start()
    {
        skill_tree = Resources.LoadAll<GameObject>("Skills/");
        turretPref = Resources.Load<GameObject>("pwj_prefab/TurretPref");

        trigger_book = true;
        trigger_ep = true;
        trigger_ice = true;
        trigger_gre = true;
        trigger_ta = true;
        tur_trigger = true;
}

    // Update is called once per frame
    void Update()
    {
        
        if (trigger_book)
        {
            UpdateBookSkill();
        }
        if (trigger_ep)
        {
            UpdateExplosion();
        }
        if (trigger_ice)
        {
            UpdateIce();
        }
        if (trigger_gre)
        {
            UpdateGrenaid();
        }
        if (trigger_ta)
        {
            UpdateTanohs();
        }
        if(tri_book_move)
        {
            moveUpdate();
        }
        if(tur_trigger)
        {
            UpdateTurret();
        }
        
        
    }
    void LateUpdate()
    {
        //w1Img.color = trigger_book ? Color.white : Color.gray;
        //w2Img.color = trigger_ep ? Color.white : Color.gray;
        //w3Img.color = trigger_ice ? Color.white : Color.gray;
        //w4Img.color = trigger_gre ? Color.white : Color.gray;
        //w5Img.color = trigger_ta ? Color.white : Color.gray;
        //w6Img.color = tur_trigger ? Color.white : Color.gray;
    }

    public void UnlockSkill(int number)  //1은 책, 2는 폭발, 3은 아이스, 4는 수류탄, 5는 타노스
    {
        switch (number)
        {
            case 1:
                trigger_book = true;
                break;
            case 2:
                trigger_ep = true;
                break;
            case 3:
                trigger_ice = true;
                break;
            case 4:
                trigger_gre = true;
                break;
            case 5:
                trigger_ta = true;
                break;
            case 6:
                tur_trigger = true;
                break;
        }

    }

    public void lockSkill(int number)
    {
        switch (number) //1은 책, 2는 폭발, 3은 아이스, 4는 수류탄, 5는 타노스
        {
            case 1:
                trigger_book = false;
                break;
            case 2:
                trigger_ep = false;
                break;
            case 3:
                trigger_ice = false;
                break;
            case 4:
                trigger_gre = false;
                break;
            case 5:
                trigger_ta = false;
                break;
            case 6:
                tur_trigger = false;
                break;
        }
    }

    void UpdateBookSkill()
    {
        b_m =  Instantiate(skill_tree[0],gameObject.transform);
        tri_book_move = true;
        trigger_book = false;
    }

    void UpdateExplosion()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject skill = Instantiate(skill_tree[1], gameObject.transform); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill, 0.2f);
            StartCoroutine(CoolTime(cool_ep, 2));
        }

    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject skill = Instantiate(skill_tree[2],gameObject.transform); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill, 0.5f);
            StartCoroutine(CoolTime(cool_ice, 3));
        }

    }

    void UpdateGrenaid()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            GameObject grenade = Instantiate(skill_tree[4],gameObject.transform);
            grenade.transform.position += fire;
            Rigidbody rb = grenade.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward * throw_power, ForceMode.Impulse);
            StartCoroutine(CoolTime(cool_gre, 4));
            Destroy(grenade, 6f);

        }
    }

    void UpdateTanohs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject t = Instantiate(skill_tree[5],gameObject.transform);
            Destroy(t, 20f);
        }
    }

    void UpdateTurret()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("터렛 생성 완료");
            Instantiate(turretPref, gameObject.transform.position + new Vector3(2.0f, 0f, 2.0f), transform.rotation);
        }
    }

    public void moveUpdate()
    {
        b_m.transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
        b_m.transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); //오브젝트가 회전

        b_angle_jhj += b_angularVelocity_jhj * Time.deltaTime;

        Vector3 offset_jhj = Quaternion.Euler(0.0f, b_angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, b_radius_jhj);

        b_m.transform.position = new Vector3(gameObject.transform.position.x, b_yPosition_jsj, gameObject.transform.position.z) + offset_jhj;
    }

    IEnumerator CoolTime(float cool, int trigger)
    {
        lockSkill(trigger);
        yield return new WaitForSeconds(cool);
        UnlockSkill(trigger);
    }
}


