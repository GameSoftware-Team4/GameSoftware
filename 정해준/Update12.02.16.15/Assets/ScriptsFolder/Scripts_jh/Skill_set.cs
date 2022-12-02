using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    GameObject b_m;
    GameObject b_1;
    GameObject b_2;

    bool trigger_6 = false;
    float cool_ep = 10f;  //������ ��Ÿ��
    float cool_ice = 10f;//���̽��� �dŸ��
    float cool_gre = 5f;//����ź�� ��Ÿ��
    public GameObject firePosition; //����ź�� ������ ��ġ;
    float throw_power = 7f; //����ź�� ������ ��

    //turret objects
    public GameObject turretPref;
    

    public float b_lv = 0;
    public float e_lv = 0;
    public float i_lv = 0;
    public float g_lv = 0;
    public float t_lv = 0;

    bool tri_book_move = false;

    public Image w1Img;
    public Image w2Img;
    public Image w3Img;
    public Image w4Img;
    public Image w5Img;
    public Image w6Img;

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
        w1Img = GameObject.Find("Canvas/Game Panel/Equip Group/Control L/W1").GetComponent<Image>();
        w2Img = GameObject.Find("Canvas/Game Panel/Equip Group/Equip 1/W2").GetComponent<Image>();
        w3Img = GameObject.Find("Canvas/Game Panel/Equip Group/Equip 2/W3").GetComponent<Image>();
        w4Img = GameObject.Find("Canvas/Game Panel/Equip Group/Equip 3/W4").GetComponent<Image>();
        w5Img = GameObject.Find("Canvas/Game Panel/Equip Group/Control R/W5").GetComponent<Image>();
        w6Img = GameObject.Find("Canvas/Game Panel/Equip Group/Control V/WV").GetComponent<Image>();

        trigger_book = false;
        trigger_ep = false;
        trigger_ice = false;
        trigger_gre = false;
        trigger_ta = false;
        tur_trigger = false;
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
        w1Img.color = trigger_book ? Color.white : Color.gray;
        w2Img.color = trigger_ep ? Color.white : Color.gray;
        w3Img.color = trigger_ice ? Color.white : Color.gray;
        w4Img.color = trigger_gre ? Color.white : Color.gray;
        w5Img.color = trigger_ta ? Color.white : Color.gray;
        w6Img.color = tur_trigger ? Color.white : Color.gray;
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
        if(b_lv == 1)
        {
            b_m = PhotonNetwork.Instantiate(Path.Combine("Skills", "Book 2"), gameObject.transform.position, gameObject.transform.rotation);
        }
        if(b_lv == 2)
        {
            b_1 = PhotonNetwork.Instantiate(Path.Combine("Skills", "Book 2"), gameObject.transform.position, gameObject.transform.rotation);
        }
        if(b_lv ==3)
        {
            b_2 = PhotonNetwork.Instantiate(Path.Combine("Skills", "Book 2"), gameObject.transform.position, gameObject.transform.rotation);
        }
            
        tri_book_move = true;
        trigger_book = false;
    }

    void UpdateExplosion()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            GameObject skill = PhotonNetwork.Instantiate(Path.Combine("Skills", "exp_eff"), gameObject.transform.position, gameObject.transform.rotation); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill, 0.6f);
            StartCoroutine(CoolTime(cool_ep, 2));
        }

    }

    void UpdateIce()
    {
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GameObject skill = PhotonNetwork.Instantiate(Path.Combine("Skills", "ice_eff"), gameObject.transform.position, gameObject.transform.rotation); //���� ��ų ������Ʈ�� �����ϰ� �����ð��� �������� ����
            Destroy(skill, 0.5f);
            StartCoroutine(CoolTime(cool_ice, 3));
        }

    }

    void UpdateGrenaid()
    {
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (g_lv >= 1)
            {
                GameObject grenade2 = PhotonNetwork.Instantiate(Path.Combine("Skills", "ThrowG2"), gameObject.transform.position, gameObject.transform.rotation);
                grenade2.transform.position += fire;
                Rigidbody rb = grenade2.GetComponent<Rigidbody>();
                rb.AddForce(Camera.main.transform.forward * throw_power, ForceMode.Impulse);
                StartCoroutine(CoolTime(cool_gre, 4));
                Destroy(grenade2, 6f);
            }
            else
            {
                GameObject grenade = PhotonNetwork.Instantiate(Path.Combine("Skills", "ThrowG"), gameObject.transform.position, gameObject.transform.rotation);
                grenade.transform.position += fire;
                Rigidbody rb = grenade.GetComponent<Rigidbody>();
                rb.AddForce(Camera.main.transform.forward * throw_power, ForceMode.Impulse);
                StartCoroutine(CoolTime(cool_gre, 4));
                Destroy(grenade, 6f);
            }
            
            

        }
    }

    void UpdateTanohs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject t = PhotonNetwork.Instantiate(Path.Combine("Skills", "T_skill"), gameObject.transform.position, gameObject.transform.rotation);
            Destroy(t, 20f);
        }
    }

    void UpdateTurret()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("�ͷ� ���� �Ϸ�");
            PhotonNetwork.Instantiate(Path.Combine("pwj_prefab","TurretPref"), gameObject.transform.position + new Vector3(2.0f, 0f, 2.0f), transform.rotation);
        }
    }

    public void moveUpdate()
    {
        b_m.transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
        b_m.transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); 
        b_angle_jhj += b_angularVelocity_jhj * Time.deltaTime;
        Vector3 offset_jhj = Quaternion.Euler(0.0f, b_angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, b_radius_jhj);
        b_m.transform.position = new Vector3(gameObject.transform.position.x, b_yPosition_jsj, gameObject.transform.position.z) + offset_jhj;
        if(b_lv >= 2)
        {
            b_1.transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
            b_1.transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); 
            b_angle_jhj += b_angularVelocity_jhj * Time.deltaTime;
            Vector3 offset_jhj1 = Quaternion.Euler(0.0f, b_angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, b_radius_jhj);
            b_1.transform.position = new Vector3(gameObject.transform.position.x, b_yPosition_jsj, gameObject.transform.position.z) + offset_jhj1;
        }
        if(b_lv >= 3)
        {
            b_2.transform.Rotate(Vector3.up * Time.deltaTime * b_degreePersecond_jhj);
            b_2.transform.Rotate(Vector3.right * Time.deltaTime * b_degreePersecond_jhj); 
            b_angle_jhj += b_angularVelocity_jhj * Time.deltaTime;
            Vector3 offset_jhj2 = Quaternion.Euler(0.0f, b_angle_jhj, 0.0f) * new Vector3(0.0f, 0.0f, b_radius_jhj);
            b_2.transform.position = new Vector3(gameObject.transform.position.x, b_yPosition_jsj, gameObject.transform.position.z) + offset_jhj2;
        }
    }

    IEnumerator CoolTime(float cool, int trigger)
    {
        lockSkill(trigger);
        yield return new WaitForSeconds(cool);
        UnlockSkill(trigger);
    }
}


