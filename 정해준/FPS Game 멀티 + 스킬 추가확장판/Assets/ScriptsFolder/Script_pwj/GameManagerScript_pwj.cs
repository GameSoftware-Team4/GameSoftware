using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript_pwj : MonoBehaviour
{
    public int totalExp = 0;
    public Player_jhj player; //resource use
    public Timer time;   //resource use
    public float stageUp_time = 720 - 81; // 스테이지 업 하는 시간대 설정
    public float stageLv = 1;
    public GameObject stageUppanel;
    //UI연동 용 필요 변수 선언 -> 서버와 통신하기 위해서는 public인 아닌 방식으로 해야할 수도?

    public GameObject gamePanel;
    public Text stage; //drag & drop
    public SpawningPool_jhj spwan; //스포닝 풀 선언   //resource use
    public Text keepMonstertxt;  //drag & drop
    //public Text maxScoreTXT;
    public Text playerHpTxt; // 체력 텍스트 연동  //drag & drop

    public Text enemyCntTxt;  //drag & drop
    public Skill_set skill_set; //resource use
    bool s_up_trigger = false;

    //스켈레벨업 할 때 나타나는 UI 모음
    public GameObject lvup_image1; //drag drop
    public GameObject lvup_image2; //drag drop
    public GameObject lvup_image3; //drag drop
    public GameObject lvup_image4; //drag drop
    public GameObject lvup_image5; //drag drop




    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player_jhj>();
        skill_set = GameObject.Find("skill_sets").GetComponent<Skill_set>();
        spwan = GameObject.Find("Spawning").GetComponent<SpawningPool_jhj>();
        time = GameObject.Find("Time Text").GetComponent<Timer>();
        gamePanel = GameObject.Find("Game Panel");


    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SetExp()
    {
        totalExp += 10;
    }

    public int GetExp()
    {
        return totalExp;
    }

    private void LateUpdate()
    {
        playerHpTxt.text = player.p_hp_jhj + " / " + player.p_starting_hp_jhj;
        stageUp(time.timeValue);
        keepMonstertxt.text = "x" + spwan.keepmonstercnt_jhj;
        skill_select();
    }

    public void stageUp(float time)
    {
        if (time < stageUp_time)
        {
            Debug.Log("stage UP!");
            stageLv++;
            stage.text = "STAGE " + stageLv;
            spwan.keepmonstercnt_jhj += 5;
            stageUp_time -= 81;
            player.p_starting_hp_jhj += 50;
            player.p_hp_jhj = player.p_starting_hp_jhj;
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
            if (Input.GetKeyDown(KeyCode.Alpha1) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(1);
                skill_set.b_lv++;
                skill_set.trigger_book = true;
                lvup_image1.SetActive(false);
                s_up_trigger = false;
                image_false();

            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(2);
                skill_set.e_lv++;
                lvup_image2.SetActive(false);
                s_up_trigger = false;
                image_false();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && Input.GetKey(KeyCode.LeftAlt))
            {
                skill_set.UnlockSkill(3);
                skill_set.i_lv++;
                lvup_image3.SetActive(false);
                s_up_trigger = false;
                image_false();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && Input.GetKey(KeyCode.LeftAlt))
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
