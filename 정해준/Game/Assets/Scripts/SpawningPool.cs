using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool : MonoBehaviour
{
    public Transform[] spwanPosArray;

    public GameObject[] monsterArray;

    public GameObject elitemonster;

    [SerializeField]
    int monstercnt = 0;

    [SerializeField]
    int keepmonstercnt = 10;

    int monsterDeathcnt = 0;

    int elitelevel = 2;


    [SerializeField]
    float spawnTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
          
    }


    private void AddMonsterCount(int value)
    {
        monstercnt += value;
    }
    public void DestroyMonster()
    {
        monstercnt -= 1;
        monsterDeathcnt++;
        if(monsterDeathcnt >= elitelevel)
        {
            SpawnElite();
            keepmonstercnt += 3;
        }
    }
    // Update is called once per frame
    void Update()
    {

        while (monstercnt < keepmonstercnt)
        {
                StartCoroutine(SpawnMonster());
                
        }

    }
    IEnumerator SpawnMonster()
    {
        monstercnt++;
        yield return new WaitForSeconds(Random.Range(0,spawnTime));

        Instantiate(monsterArray[Random.Range(0, 2)], spwanPosArray[Random.Range(0, 4)]);

    }      

    void SpawnElite()
    {
    
        Instantiate(elitemonster, spwanPosArray[Random.Range(0, 4)]);
        monsterDeathcnt = 0;
    }
}
