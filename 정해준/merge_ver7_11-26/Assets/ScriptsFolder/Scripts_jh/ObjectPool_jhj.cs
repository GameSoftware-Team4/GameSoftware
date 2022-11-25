using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_jhj : MonoBehaviour
{
    public static ObjectPool_jhj Instance;
    [SerializeField]
    private GameObject[] poolingObjectPrefab;
   

    Queue<Mob> poolingObjectQueue = new Queue<Mob>();

    private void Awake()
    {
        Instance = this;
        poolingObjectPrefab = Resources.LoadAll<GameObject>("monsters");
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
        var newObj = Instantiate(poolingObjectPrefab[Random.Range(0,3)]).GetComponent<Mob>();
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
