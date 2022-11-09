using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : LivingEntity
{
    public float damage = 20f; //공격력
    public float attackDelay = 1f; //공격딜레이
    private float lastAttackTime;
    private float dist;
    

    public Transform tr;
    private LivingEntity targetEntity;
    private NavMeshAgent pathFinder;
    //private float attackRange = 2.3f;
    private Animator enemyAnimator;
    /*private bool hasTarget
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

    private bool canMove;
    private bool canAttack;

    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    public void Setup(float newHp, float newDamage)
    {
        starting_hp = newHp;
        hp = newHp;
        damage = newDamage;

    }

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
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