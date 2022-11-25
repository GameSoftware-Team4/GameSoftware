using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool_jhj : MonoBehaviour
{
    public GameObject[] spwanPosArray_jhj; //스폰할 위치들을 저장

    public GameObject[] monsterArray_jhj; //스폰시킬 몬스터들을 저장

    public GameObject elitemonster_jhj; //몬스터 중 엘리트 몬스터를 저장

    [SerializeField]
    int monstercnt_jhj = 0; //생성되는 몬스터 개체수를 저장할 변수

   
    public float keepmonstercnt_jhj = 10; //유지해야할 몬스터 개체수를 저장할 변수

    float monsterDeathcnt_jhj = 0;  //처치된 몬스터의 수를 저장하는 변수

    int Level_up_jhj = 5; //레벨업에 필요한 처치된 몬스터의 수를 저장하는 변수


    [SerializeField]
    float spawnTime_jhj = 5f; //스폰하는 간격을 저장하는 변수
    // Start is called before the first frame update
    void Start()
    {
        spwanPosArray_jhj = Resources.LoadAll<GameObject>("Spawnpos");
        monsterArray_jhj = Resources.LoadAll<GameObject>("monsters");
        elitemonster_jhj = Resources.Load<GameObject>("Enemy");
    }

    public void DestroyMonster() //몬스터가 처치됬을 때 존재하는 몬스터의 수를 줄이고 처치된 수를 증가
    {
        monstercnt_jhj -= 1;
        monsterDeathcnt_jhj++;
        if(monsterDeathcnt_jhj >= Level_up_jhj) //만약 처치된 수가 level업 기준을 달성할 경우 엘리트 몹을 스폰
        {
            spawnLevelUp();  //유지할 개체수 증가
        } //경험치 시스템이 확립되면 삭제 후 spawnLevelUp함수 호출로 변경;
    }
    // Update is called once per frame
    void Update()
    {


       StartCoroutine(SpawnMonster());
                
        

    }
    IEnumerator SpawnMonster() //저장한 장소중 랜덤한 장소에서 랜덤의 몬스터가 스폰된다.
    {
        if(monstercnt_jhj < keepmonstercnt_jhj)
        {
            monstercnt_jhj++;
            yield return new WaitForSeconds(Random.Range(0, spawnTime_jhj));
            var mob = ObjectPool_jhj.GetObject();    // objectPooling


            mob.transform.position = spwanPosArray_jhj[Random.Range(0, 2)].transform.position;
            //GameObject mob = Instantiate(monsterArray_jhj[Random.Range(0, 1)]); //위치 배열에 저장된것을 사용하면 오류뜸
            //mob.transform.position = spwanPosArray_jhj[Random.Range(0, 2)].transform.position;
        }


    }

    void SpawnElite()
    {
    
        //Instantiate(elitemonster_jhj, spwanPosArray_jhj[Random.Range(0, 3)].transform);
        monsterDeathcnt_jhj = 0;
    }
    public void spawnLevelUp()
    {
        SpawnElite();
    }
}
