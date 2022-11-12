using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool_jhj : MonoBehaviour
{
    public Transform[] spwanPosArray_jhj; //������ ��ġ���� ����

    public GameObject[] monsterArray_jhj; //������ų ���͵��� ����

    public GameObject elitemonster_jhj; //���� �� ����Ʈ ���͸� ����

    [SerializeField]
    int monstercnt_jhj = 0; //�����Ǵ� ���� ��ü���� ������ ����

    [SerializeField]
    int keepmonstercnt_jhj = 10; //�����ؾ��� ���� ��ü���� ������ ����

    int monsterDeathcnt_jhj = 0;  //óġ�� ������ ���� �����ϴ� ����

    int Level_up_jhj = 2; //�������� �ʿ��� óġ�� ������ ���� �����ϴ� ����


    [SerializeField]
    float spawnTime_jhj = 5f; //�����ϴ� ������ �����ϴ� ����
    // Start is called before the first frame update
    void Start()
    {
          
    }

    public void DestroyMonster() //���Ͱ� óġ���� �� �����ϴ� ������ ���� ���̰� óġ�� ���� ����
    {
        monstercnt_jhj -= 1;
        monsterDeathcnt_jhj++;
        if(monsterDeathcnt_jhj >= Level_up_jhj) //���� óġ�� ���� level�� ������ �޼��� ��� ����Ʈ ���� ����
        {
            SpawnElite();
            keepmonstercnt_jhj += 3;  //������ ��ü�� ����
        }
    }
    // Update is called once per frame
    void Update()
    {

        while (monstercnt_jhj < keepmonstercnt_jhj) //�����ϴ� ���Ͱ� �����Ǿ�� �� ��ġ���� ���� �� ����
        {
                StartCoroutine(SpawnMonster());
                
        }

    }
    IEnumerator SpawnMonster() //������ ����� ������ ��ҿ��� ������ ���Ͱ� �����ȴ�.
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
