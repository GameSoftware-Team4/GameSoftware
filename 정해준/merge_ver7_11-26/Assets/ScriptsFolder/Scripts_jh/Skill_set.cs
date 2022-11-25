using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_set : MonoBehaviour
{
    //public Camera followCamera; 
    public GameObject[] skill_tree;
    bool trigger_book = false;
    bool trigger_ep = false;
    bool trigger_ice = false;
    bool trigger_gre = false;
    bool trigger_ta = true;
    bool trigger_6 = false;
    float cool_ep = 10f;  //������ ��Ÿ��
    float cool_ice = 10f;//���̽��� �dŸ��
    float cool_gre = 5f;//����ź�� ��Ÿ��
    public GameObject firePosition; //����ź�� ������ ��ġ;
    float throw_power = 7f; //����ź�� ������ ��

    public float b_lv = 0;
    public float e_lv = 0;
    public float i_lv = 0;
    public float g_lv = 0;
    public float t_lv = 0;


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

    public void UnlockSkill(int number)  //1�� å, 2�� ����, 3�� ���̽�, 4�� ����ź, 5�� Ÿ�뽺
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
        switch (number) //1�� å, 2�� ����, 3�� ���̽�, 4�� ����ź, 5�� Ÿ�뽺
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
            GameObject skill = Instantiate(skill_tree[1]); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill, 0.2f);
            StartCoroutine(CoolTime(cool_ep,2));
        }
        
    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject skill = Instantiate(skill_tree[2]); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
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


