using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{    //resource use
    PlayerController player;
    public Timer time;   //resource use
    public float stageUp_time = 720 - 81; // �������� �� �ϴ� �ð��� ����
    public float stageLv;
    public GameObject stageUppanel;


    public GameObject gamePanel;
    public Text stage; //drag & drop
    //public SpawningPool_jhj spwan; //������ Ǯ ����   //resource use
    public Text keepMonstertxt;  //drag & drop
    //public Text maxScoreTXT;
    public Text playerHpTxt; // ü�� �ؽ�Ʈ ����  //drag & drop

    public Text enemyCntTxt;  //drag & drop
    public Skill_set skill_set; //resource use
    bool s_up_trigger;

    //���̷����� �� �� ��Ÿ���� UI ����
    public GameObject lvup_image1;
    public GameObject lvup_image2;
    public GameObject lvup_image3;
    public GameObject lvup_image4;
    public GameObject lvup_image5;
    public GameObject lvup_image6;

    [SerializeField]
    private GunController_kjw theGunController;
    private Gun_kjw currentGun;

    [SerializeField]
    private GameObject go_BulletHUD;

    public Text text_Bullet1;
    public Text text_Bullet2;


    private void Start()
    {
        stageUp_time = 710;
        stageLv = 1;
        s_up_trigger = false;

        player = gameObject.GetComponent<PlayerController>();
        skill_set = gameObject.GetComponent<Skill_set>();
        playerHpTxt = GameObject.Find("Canvas/Game Panel/Status Group/Health Text").GetComponent<Text>();
        stage = GameObject.Find("Canvas/Game Panel/Stage Group/Stage Text").GetComponent<Text>();

        text_Bullet1 = GameObject.Find("Canvas/Game Panel/Status Group/Ammo UI/ReloadBullet").GetComponent<Text>();
        text_Bullet2 = GameObject.Find("Canvas/Game Panel/Status Group/Ammo UI/CurrentBullet").GetComponent<Text>();

        //spwan = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        time = GameObject.Find("Time Text").GetComponent<Timer>();
        gamePanel = GameObject.Find("Game Panel");
        stageUppanel = GameObject.Find("Canvas/Game Panel/Stage Group/StageUp UI");
        stageUppanel.SetActive(false);

        lvup_image1 = GameObject.Find("Canvas/Game Panel/Equip Group/Control L/1");
        lvup_image2 = GameObject.Find("Canvas/Game Panel/Equip Group/Equip 1/2");
        lvup_image3 = GameObject.Find("Canvas/Game Panel/Equip Group/Equip 2/3");
        lvup_image4 = GameObject.Find("Canvas/Game Panel/Equip Group/Equip 3/4");
        lvup_image5 = GameObject.Find("Canvas/Game Panel/Equip Group/Control R/5");
        lvup_image6 = GameObject.Find("Canvas/Game Panel/Equip Group/Control V/6");
        image_false();

        
    }

    private void LateUpdate()
    {
        playerHpTxt.text = player.currentHealth + " / " + player.maxHealth;
        stageUp(time.timeValue);
        //keepMonstertxt.text = "x" + spwan.keepmonstercnt_jhj;
        skill_select();
        CheckBullet();

    }

    public void stageUp(float time)
    {
        if (time < stageUp_time)
        {
            Debug.Log("stage UP!");
            stageLv++;
            stage.text = "STAGE " + stageLv;
            //spwan.keepmonstercnt_jhj += 5;
            stageUp_time -= 5;
            player.maxHealth += 50;
            player.currentHealth = player.maxHealth;
            StartCoroutine(stageup_message());
            skill_lv();
        }
    }

    IEnumerator stageup_message()
    {
        stageUppanel.SetActive(true);
        yield return new WaitForSeconds(1f);
        stageUppanel.SetActive(false);
    }
    void skill_lv()
    {
        if (skill_set.b_lv < 3)
        {
            lvup_image1.SetActive(true);
        }

        if (skill_set.e_lv == 0)
        {
            lvup_image2.SetActive(true);
        }

        if (skill_set.i_lv == 0)
        {
            lvup_image3.SetActive(true);
        }

        if (skill_set.g_lv < 2)
        {
            lvup_image4.SetActive(true);
        }

        if (skill_set.t_lv == 0)
        {
            lvup_image5.SetActive(true);
        }
        s_up_trigger = true;
        if (skill_set.tur_lv == 0)
        {
            lvup_image6.SetActive(true);
        }
        s_up_trigger = true;
    }
    void skill_select()
    {

        if (s_up_trigger)
        {

            if (Input.GetKeyDown(KeyCode.Keypad1) && Input.GetKey(KeyCode.LeftAlt))
            {

                skill_set.UnlockSkill(1);
                skill_set.b_lv++;
                skill_set.trigger_book = true;
                lvup_image1.SetActive(false);
                s_up_trigger = false;
                image_false();

            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) && Input.GetKey(KeyCode.LeftAlt))
            {

                skill_set.UnlockSkill(2);
                skill_set.e_lv++;
                lvup_image2.SetActive(false);
                s_up_trigger = false;
                image_false();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(3);
                skill_set.i_lv++;
                lvup_image3.SetActive(false);
                s_up_trigger = false;
                image_false();
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(4);
                skill_set.g_lv++;
                lvup_image4.SetActive(false);
                s_up_trigger = false;
                image_false();
            }
            else if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(5);
                skill_set.t_lv++;
                lvup_image5.SetActive(false);
                s_up_trigger = false;
                image_false();

            }
            else if (Input.GetKeyDown(KeyCode.V) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(6);
                skill_set.tur_lv++;
                lvup_image6.SetActive(false);
                s_up_trigger = false;
                image_false();

            }



        }

    }
    void image_false()
    {
        lvup_image1.SetActive(false);
        lvup_image2.SetActive(false);
        lvup_image3.SetActive(false);
        lvup_image4.SetActive(false);
        lvup_image5.SetActive(false);
        lvup_image6.SetActive(false);
    }

    private void CheckBullet()
    {
        currentGun = theGunController.GetGun();
        text_Bullet1.text = currentGun.reloadBulletCount.ToString();
        text_Bullet2.text = currentGun.currentBulletCount.ToString();
    }
}
