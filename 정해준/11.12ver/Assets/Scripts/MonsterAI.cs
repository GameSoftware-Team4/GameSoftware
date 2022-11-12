using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    GameObject target_jhj;
    NavMeshAgent navMeshAgent_jhj;

    //public Define.WorldObject type_jhj = Define.WorldObject.Monster; //몬스터AI임을 증명


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent_jhj = GetComponent<NavMeshAgent>();
        target_jhj = GameObject.Find("Player");


    }
    /*public Define.WorldObject returnType()
    {
        return type;
    }*/

    // Update is called once per frame
    void Update()
    {
        navMeshAgent_jhj.SetDestination(target_jhj.transform.position);

    }
}


