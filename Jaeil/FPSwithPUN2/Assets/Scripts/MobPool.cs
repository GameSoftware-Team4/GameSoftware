using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class MobPool : MonoBehaviourPunCallbacks
{
    PhotonView PV;
    public static MobPool Instance;
    [SerializeField]
    private string[] poolingObjectPrefabName;
   

    Queue<Mob> poolingObjectQueue = new Queue<Mob>();

    private void Awake()
    {
        Instance = this;
        if(PhotonNetwork.IsMasterClient)
            Initialize(10);
    }

    private void Initialize(int initCount)
    {
        for(int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    private Mob CreateNewObject()
    {
        var newObj = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", poolingObjectPrefabName[Random.Range(0,poolingObjectPrefabName.Length)]), Vector3.zero, Quaternion.identity).GetComponent<Mob>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static Mob GetObject()
    {
        if (Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(Mob obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
