using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript_pwj : MonoBehaviour
{
    public int totalExp = 0;
    public Player_jhj player;
    public Mob mob;
    public bool isBattle;
    public Timer time;
    public float  stageUp_time = 890; // 스테이지 업 하는 시간대 설정
    public float stageLv = 1;
    //UI연동 용 필요 변수 선언 -> 서버와 통신하기 위해서는 public인 아닌 방식으로 해야할 수도?
    public GameObject menuPanel;
    public GameObject gamePanel;
    public Text stage;
    public SpawningPool_jhj spwan; //스포닝 풀 선언
    public Text keepMonstertxt;
    //public Text maxScoreTXT;
    public Text playerHpTxt; // 체력 텍스트 연동
    public Image weapon1Img;
    public Image weapon2Img;
    public Image weapon3Img;
    public Image weapon4Img;
    public Text enemyCntTxt;

    private void Start()
    {
        
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

    }

    public void stageUp(float time)
    {
        if (time < stageUp_time)
        { Debug.Log("stage UP!");
            stageLv++;
            stage.text = "STAGE " + stageLv;
            spwan.keepmonstercnt_jhj += 5;
            stageUp_time -= 20;
        }
    }
}
