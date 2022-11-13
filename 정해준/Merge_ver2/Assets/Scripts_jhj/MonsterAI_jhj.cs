using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI_jhj : MonoBehaviour
{
    GameObject target_jhj;
    NavMeshAgent navMeshAgent_jhj;



    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent_jhj = GetComponent<NavMeshAgent>();
        target_jhj = GameObject.Find("Player");


    }


    // Update is called once per frame
    void Update()
    {
        navMeshAgent_jhj.SetDestination(target_jhj.transform.position);

    }
}


