using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool_jhj : MonoBehaviour
{
    public Transform[] spwanPosArray_jhj; //스폰할 위치들을 저장

    public GameObject[] monsterArray_jhj; //스폰시킬 몬스터들을 저장

    public GameObject elitemonster_jhj; //몬스터 중 엘리트 몬스터를 저장

    [SerializeField]
    int monstercnt_jhj = 0; //생성되는 몬스터 개체수를 저장할 변수

    [SerializeField]
    int keepmonstercnt_jhj = 10; //유지해야할 몬스터 개체수를 저장할 변수

    int monsterDeathcnt_jhj = 0;  //처치된 몬스터의 수를 저장하는 변수

    int Level_up_jhj = 2; //레벨업에 필요한 처치된 몬스터의 수를 저장하는 변수


    [SerializeField]
    float spawnTime_jhj = 5f; //스폰하는 간격을 저장하는 변수
    // Start is called before the first frame update
    void Start()
    {
          
    }

    public void DestroyMonster() //몬스터가 처치됬을 때 존재하는 몬스터의 수를 줄이고 처치된 수를 증가
    {
        monstercnt_jhj -= 1;
        monsterDeathcnt_jhj++;
        if(monsterDeathcnt_jhj >= Level_up_jhj) //만약 처치된 수가 level업 기준을 달성할 경우 엘리트 몹을 스폰
        {
            SpawnElite();
            keepmonstercnt_jhj += 3;  //유지할 개체수 증가
        }
    }
    // Update is called once per frame
    void Update()
    {

        while (monstercnt_jhj < keepmonstercnt_jhj) //존재하는 몬스터가 유지되어야 할 수치보다 적을 시 스폰
        {
                StartCoroutine(SpawnMonster());
                
        }

    }
    IEnumerator SpawnMonster() //저장한 장소중 랜덤한 장소에서 랜덤의 몬스터가 스폰된다.
    {
        monstercnt_jhj++;
        yield return new WaitForSeconds(Random.Range(0, spawnTime_jhj));

        Instantiate(monsterArray_jhj[Random.Range(0, 2)], spwanPosArray_jhj[Random.Range(0, 4)]); 

    }      

    void SpawnElite()
    {
    
        Instantiate(elitemonster_jhj, spwanPosArray_jhj[Random.Range(0, 4)]);
        monsterDeathcnt_jhj = 0;
    }
}
