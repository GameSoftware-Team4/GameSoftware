using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_set : MonoBehaviour
{
    //public Camera followCamera; 
    public GameObject[] skill_tree;
    bool trigger_1 = false;
    bool trigger_2 = true;
    bool trigger_3 = true;
    bool trigger_4 = true;
    bool trigger_5 = false;
    bool trigger_6 = false;
    float cool_ep = 3f;
    public GameObject firePosition;
    float throw_power = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (trigger_1)
        {
            UpdateBookSkill();
        }
        if (trigger_2)
        {
            UpdateExplosion();
        }
        if (trigger_3)
        {
            UpdateIce();
        }
        if (trigger_4 )
        {
            UpdateGrenaid();
        }
        if (trigger_5)
        {

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
                trigger_1 = true;
                break;
            case 2:
                trigger_2 = true;
                break;
            case 3:
                trigger_3 = true;
                break;
            case 4:
                trigger_4 = true;
                break;
            case 5:
                trigger_5 = true;
                break;
            case 6:
                trigger_6 = true;
                break;
        }

    }

    void UpdateBookSkill()
    {
        Instantiate(skill_tree[0]);
        trigger_1 = false;
    }

    void UpdateExplosion()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject skill = Instantiate(skill_tree[1]); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill, 0.2f);
            trigger_1 = true;
            StartCoroutine(CoolTime(cool_ep));
        }
        
    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject skill = Instantiate(skill_tree[2]); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill, 0.5f);
            StartCoroutine(CoolTime(cool_ep));
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
            
        }
    }

    IEnumerator CoolTime(float cool)    
    {
        while (cool > 1.0f)
        {
            cool -= Time.deltaTime;
            yield return new WaitForFixedUpdate();

        }
    }
}


