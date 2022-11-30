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
    float cool_ep = 10f;  //������ ��Ÿ��
    float cool_ice = 10f;//���̽��� �dŸ��
    float cool_gre = 5f;//����ź�� ��Ÿ��
    public GameObject firePosition; //����ź�� ������ ��ġ;
    float throw_power = 7f; //����ź�� ������ ��

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

    float b_yPosition_jsj = 0.7f;  //y�� ��ġ

    float b_radius_jhj = 5.0f;   // �̵��ϴ� �������� ũ��

    public float b_angularVelocity_jhj = 360.0f; //�ӵ�

    public float b_angle_jhj = 0.0f; //����

    float b_degreePersecond_jhj = 200;  //�ֺ��� �� �� ��ü��ü�� ȸ���� �� �ʴ� �����̴� ��ġ

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
                tur_trigger = true;
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
            GameObject skill = Instantiate(skill_tree[1], gameObject.transform); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill, 0.2f);
            StartCoroutine(CoolTime(cool_ep, 2));
        }

    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameObject skill = Instantiate(skill_tree[2],gameObject.transform); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
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
            Debug.Log("�ͷ� ���� �Ϸ�");
            Instantiate(turretPref, gameObject.transform.position + new Vector3(2.0f, 0f, 2.0f), transform.rotation);
        }
    }

    public void moveUpdate()
    {
        b_m.transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
        b_m.transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); //������Ʈ�� ȸ��

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


