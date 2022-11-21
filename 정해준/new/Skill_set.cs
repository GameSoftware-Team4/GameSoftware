using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_set : MonoBehaviour
{
    //public Camera followCamera; 
    public GameObject[] skill_tree;
    bool trigger_book = false;
    bool trigger_ep = true;
    bool trigger_ice = true;
    bool trigger_gre = true;
    bool trigger_ta = true;
    bool trigger_6 = false;
    float cool_ep = 10f;
    float cool_ice = 10f;
    float cool_gre = 5f;
    public GameObject firePosition;
    float throw_power = 7f;

    // Start is called before the first frame update
    void Start()
    {

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
        if (trigger_gre )
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

    public void UnlockSkill(int number)
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
        switch (number)
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
        if (Input.GetMouseButtonDown(1))
        {
            GameObject skill = Instantiate(skill_tree[1]); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill, 0.2f);
            trigger_book = true;
            StartCoroutine(CoolTime(cool_ep,2));
        }
        
    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject skill = Instantiate(skill_tree[2]); //범위 스킬 오브젝트를 생성하고 일정시간후 프리펩을 제거
            Destroy(skill, 0.5f);
            StartCoroutine(CoolTime(cool_ice,3));
        }
        
    }
    
    void UpdateGrenaid()
    {
        if(Input.GetKeyDown(KeyCode.C))
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
        if(Input.GetKeyDown(KeyCode.T))
        {
            GameObject t = Instantiate(skill_tree[4]);
            Destroy(t, 2f);
        }
    }

    IEnumerator CoolTime(float cool, int trigger)    
    {
        lockSkill(trigger);
        yield return new WaitForSeconds(cool);
        UnlockSkill(trigger);
    }
}


