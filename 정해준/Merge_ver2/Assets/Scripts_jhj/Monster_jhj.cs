using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster_jhj : LivingEntity_jhj
{
    public float damage_jhj = 20f; //���ݷ�
    public float attackDelay = 1f; //���ݵ�����
    private float lastAttackTime;
    private float dist;
    

    public Transform tr;
    private LivingEntity_jhj targetEntity;
    private NavMeshAgent pathFinder;
    
    private Animator enemyAnimator;

    public Define_jhj.WorldObject_jhj type_jhj = Define_jhj.WorldObject_jhj.Monster; //����Ÿ������ ����

    private void Awake()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
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