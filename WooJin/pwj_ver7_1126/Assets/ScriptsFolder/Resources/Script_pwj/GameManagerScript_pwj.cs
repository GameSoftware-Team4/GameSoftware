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
    public float  stageUp_time = 890; // �������� �� �ϴ� �ð��� ����
    public float stageLv = 1;
    //UI���� �� �ʿ� ���� ���� -> ������ ����ϱ� ���ؼ��� public�� �ƴ� ������� �ؾ��� ����?
    public GameObject menuPanel;
    public GameObject gamePanel;
    public Text stage;
    public SpawningPool_jhj spwan; //������ Ǯ ����
    public Text keepMonstertxt;
    //public Text maxScoreTXT;
    public Text playerHpTxt; // ü�� �ؽ�Ʈ ����
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
