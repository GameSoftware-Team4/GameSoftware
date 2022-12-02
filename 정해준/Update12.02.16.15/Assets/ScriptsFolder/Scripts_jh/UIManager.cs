using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{    //resource use
    PlayerController player;
    public Timer time;   //resource use
    public float stageUp_time = 720 - 81; // 스테이지 업 하는 시간대 설정
    public float stageLv;
    public GameObject stageUppanel;


    public GameObject gamePanel;
    public Text stage; //drag & drop
    //public SpawningPool_jhj spwan; //스포닝 풀 선언   //resource use
    public Text keepMonstertxt;  //drag & drop
    //public Text maxScoreTXT;
    public Text playerHpTxt; // 체력 텍스트 연동  //drag & drop

    public Text enemyCntTxt;  //drag & drop
    public Skill_set skill_set; //resource use
    bool s_up_trigger;

    //스켈레벨업 할 때 나타나는 UI 모음
    public GameObject lvup_image1; //drag drop
    public GameObject lvup_image2; //drag drop
    public GameObject lvup_image3; //drag drop
    public GameObject lvup_image4; //drag drop
    public GameObject lvup_image5; //drag drop


    private void Start()
    {
        stageUp_time = 710;
        stageLv = 1;
        s_up_trigger = false;

        player = gameObject.GetComponent<PlayerController>();
        skill_set = gameObject.GetComponent<Skill_set>();
        playerHpTxt = GameObject.Find("Canvas/Game Panel/Status Group/Health Text").GetComponent<Text>();
        stage = GameObject.Find("Canvas/Game Panel/Stage Group/Stage Text").GetComponent<Text>();

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
        lvup_image1.SetActive(false);
        lvup_image2.SetActive(false);
        lvup_image3.SetActive(false);
        lvup_image4.SetActive(false);
        lvup_image5.SetActive(false);
    }

    private void LateUpdate()
    {
        playerHpTxt.text = player.currentHealth + " / " + player.maxHealth;
        stageUp(time.timeValue);
        //keepMonstertxt.text = "x" + spwan.keepmonstercnt_jhj;
        skill_select();
  
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



        }

    }
    void image_false()
    {
        lvup_image1.SetActive(false);
        lvup_image2.SetActive(false);
        lvup_image3.SetActive(false);
        lvup_image4.SetActive(false);
        lvup_image5.SetActive(false);
    }
}
