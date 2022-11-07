using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    GameObject target;
    NavMeshAgent navMeshAgent;
    
    public Define.WorldObject type = Define.WorldObject.Monster;
    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player");


    }
    public Define.WorldObject returnType()
    {
        Debug.Log("return");
        return type;
    }
    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(target.transform.position);

    }
}


