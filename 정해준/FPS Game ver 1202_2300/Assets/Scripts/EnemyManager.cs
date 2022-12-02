using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class EnemyManager : MonoBehaviourPunCallbacks
{
    PhotonView PV;

    [SerializeField]
    int monsterCnt = 0; //�����Ǵ� ���� ��ü���� ������ ����
    [SerializeField]
    private string[] poolingObjectPrefabName;


    public float keepMonsterCnt = 1; //�����ؾ��� ���� ��ü���� ������ ����

    float monsterDeathCnt = 0;  //óġ�� ������ ���� �����ϴ� ����

    int levelUp = 5; //�������� �ʿ��� óġ�� ������ ���� �����ϴ� ����


    [SerializeField]
    float spawnTime = 5f; //�����ϴ� ������ �����ϴ� ����

    bool isMaster = false;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        isMaster = PhotonNetwork.IsMasterClient;
    }

    public void DestroyMonster() //���Ͱ� óġ���� �� �����ϴ� ������ ���� ���̰� óġ�� ���� ����
    {
        monsterCnt -= 1;
        monsterDeathCnt++;
        if (monsterDeathCnt >= levelUp) //���� óġ�� ���� level�� ������ �޼��� ��� ����Ʈ ���� ����
        {
            spawnLevelUp();  //������ ��ü�� ����
        } //����ġ �ý����� Ȯ���Ǹ� ���� �� spawnLevelUp�Լ� ȣ��� ����;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMaster)
            StartCoroutine(SpawnMonster());
    }
    IEnumerator SpawnMonster() //������ ����� ������ ��ҿ��� ������ ���Ͱ� �����ȴ�.
    {
        if (monsterCnt < keepMonsterCnt)
        {
            monsterCnt++;
            yield return new WaitForSeconds(Random.Range(0, spawnTime));
            Transform spawnpoint = SpawnManager.Instance.GetSpawnpoint();
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", poolingObjectPrefabName[Random.Range(0, poolingObjectPrefabName.Length)]), spawnpoint.position, spawnpoint.rotation, 0, new object[] { PV.ViewID });
        }
    }

    void SpawnElite()
    {
        monsterDeathCnt = 0;
    }
    public void spawnLevelUp()
    {
        SpawnElite();
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        monsterCnt = 0;
        isMaster = PhotonNetwork.IsMasterClient;
    }
}
