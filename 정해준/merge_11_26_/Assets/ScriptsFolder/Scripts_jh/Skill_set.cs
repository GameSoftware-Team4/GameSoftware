using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill_set : MonoBehaviour
{
    //public Camera followCamera; 
    public GameObject[] skill_tree;
    public bool trigger_book = false;
    public bool trigger_ep = false;
    public bool trigger_ice = false;
    public bool trigger_gre = false;
    public bool trigger_ta = false;
    bool trigger_6 = false;
    float cool_ep = 10f;  //폭발의 쿨타임
    float cool_ice = 10f;//아이스의 쿭타임
    float cool_gre = 5f;//수류탄의 쿨타임
    public GameObject firePosition; //수류탄의 던지는 위치;
    float throw_power = 7f; //수류탄을 던지는 힘

    public float b_lv = 0;
    public float e_lv = 0;
    public float i_lv = 0;
    public float g_lv = 0;
    public float t_lv = 0;

    public Image w1Img;
    public Image w2Img;
    public Image w3Img;
    public Image w4Img;
    public Image w5Img;

    // Start is called before the first frame update
    void Start()
    {
        skill_tree = Resources.LoadAll<GameObject>("Skills/");
        firePosition = GameObject.Find("fireposition");
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
        if (trigger_6)
        {

        }
    }
    void LateUpdate()
    {
        w1Img.color = trigger_book ? Color.white : Color.gray;
        w2Img.color = trigger_ep ? Color.white : Color.gray;
        w3Img.color = trigger_ice ? Color.white : Color.gray;
        w4Img.color = trigger_gre ? Color.white : Color.gray;
        w5Img.color = trigger_ta ? Color.white : Color.gray;
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
                trigger_6 = true;
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
                trigger_6 = false;
                break;
        }
    }

    void UpdateBookSkill()
    {
        Instantiate(skill_tree[0]);
        trigger_book = false;
    }

    void UpdateExplosion()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameObject skill = Instantiate(skill_tree[1]); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill, 0.2f);
            StartCoroutine(CoolTime(cool_ep, 2));
        }

    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject skill = Instantiate(skill_tree[2]); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill, 0.5f);
            StartCoroutine(CoolTime(cool_ice, 3));
        }

    }

    void UpdateGrenaid()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {

            GameObject grenade = Instantiate(skill_tree[3]);
            grenade.transform.position = firePosition.transform.position;
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
            GameObject t = Instantiate(skill_tree[5]);
            Destroy(t, 20f);
        }
    }

    IEnumerator CoolTime(float cool, int trigger)
    {
        lockSkill(trigger);
        yield return new WaitForSeconds(cool);
        UnlockSkill(trigger);
    }
}


