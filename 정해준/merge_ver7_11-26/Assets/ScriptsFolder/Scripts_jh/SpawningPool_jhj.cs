using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningPool_jhj : MonoBehaviour
{
    public GameObject[] spwanPosArray_jhj; //������ ��ġ���� ����

    public GameObject[] monsterArray_jhj; //������ų ���͵��� ����

    public GameObject elitemonster_jhj; //���� �� ����Ʈ ���͸� ����

    [SerializeField]
    int monstercnt_jhj = 0; //�����Ǵ� ���� ��ü���� ������ ����

   
    public float keepmonstercnt_jhj = 10; //�����ؾ��� ���� ��ü���� ������ ����

    float monsterDeathcnt_jhj = 0;  //óġ�� ������ ���� �����ϴ� ����

    int Level_up_jhj = 5; //�������� �ʿ��� óġ�� ������ ���� �����ϴ� ����


    [SerializeField]
    float spawnTime_jhj = 5f; //�����ϴ� ������ �����ϴ� ����
    // Start is called before the first frame update
    void Start()
    {
        spwanPosArray_jhj = Resources.LoadAll<GameObject>("Spawnpos");
        monsterArray_jhj = Resources.LoadAll<GameObject>("monsters");
        elitemonster_jhj = Resources.Load<GameObject>("Enemy");
    }

    public void DestroyMonster() //���Ͱ� óġ���� �� �����ϴ� ������ ���� ���̰� óġ�� ���� ����
    {
        monstercnt_jhj -= 1;
        monsterDeathcnt_jhj++;
        if(monsterDeathcnt_jhj >= Level_up_jhj) //���� óġ�� ���� level�� ������ �޼��� ��� ����Ʈ ���� ����
        {
            spawnLevelUp();  //������ ��ü�� ����
        } //����ġ �ý����� Ȯ���Ǹ� ���� �� spawnLevelUp�Լ� ȣ��� ����;
    }
    // Update is called once per frame
    void Update()
    {


       StartCoroutine(SpawnMonster());
                
        

    }
    IEnumerator SpawnMonster() //������ ����� ������ ��ҿ��� ������ ���Ͱ� �����ȴ�.
    {
        if(monstercnt_jhj < keepmonstercnt_jhj)
        {
            monstercnt_jhj++;
            yield return new WaitForSeconds(Random.Range(0, spawnTime_jhj));
            var mob = ObjectPool_jhj.GetObject();    // objectPooling


            mob.transform.position = spwanPosArray_jhj[Random.Range(0, 2)].transform.position;
            //GameObject mob = Instantiate(monsterArray_jhj[Random.Range(0, 1)]); //��ġ �迭�� ����Ȱ��� ����ϸ� ������
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
