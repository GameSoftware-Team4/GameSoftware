using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LowMob_jhj : Mob_jhj
{
    //public float damage_jhj = 20f; //���ݷ�
    public float attackDelay = 1f; //���ݵ�����
    private float lastAttackTime;
    private float dist;
    public float damage_jhj = 10;

    public Transform tr;
    
    private NavMeshAgent pathFinder;
   

    
    
    public Define_jhj.WorldObject_jhj type_jhj = Define_jhj.WorldObject_jhj.Monster; //����Ÿ������ ����

    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>();
    }

    public void Setup(float newHp, float newDamage)
    {
        starting_hp_jhj += newHp;
        hp_jhj = starting_hp_jhj;
        damage_jhj = newDamage;
        Debug.Log("ü��1: " + hp_jhj);
    }
    

    // Start is called before the first frame update
    void Start()
    {
        Setup(10, 10);
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnDamage(float damage)
    {
        Debug.Log("ü��2: " + hp_jhj);
        base.OnDamage(damage);
        
    }

    public override void Die()
    {
        
        base.Die();
    }
}