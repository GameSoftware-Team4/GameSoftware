using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_Ani : LivingEntity_jhj
{
    public float damage_jhj = 20f; //공격력
    public float attackDelay_jhj = 1f; //공격딜레이
    private float lastAttackTime_jhj;
    private float dist_jhj;
    

    //public Transform tr;
    private LivingEntity_jhj targetEntity_jhj;
    private NavMeshAgent pathFinder_jhj;
    //private float attackRange_jhj = 2.3f;
    private Animator enemyAnimator_jhj;
    /*private bool hasTarget_jhj;
    {
        get
        {
            if(targetEntity != null && !targetEntitiy.dead)
            {
                return true;
            }
            return false;
        }
    }*/



    private void Awake()
    {
        pathFinder_jhj = GetComponent<NavMeshAgent>();
        enemyAnimator_jhj = GetComponent<Animator>();
    }

    public void Setup(float newHp, float newDamage)
    {
        starting_hp_jhj = newHp;
        hp_jhj = newHp;
        damage_jhj = newDamage;

    }

    // Start is called before the first frame update
    void Start()
    {
        //tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void OnDamage(float damage)
    {
        base.OnDamage(damage);
    }

    public override void Die()
    {
        base.Die();
    }
}