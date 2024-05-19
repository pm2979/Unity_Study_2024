using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterComponent : MonoBehaviour
{
    public int maxHealth; //최대 체력
    public Transform target; //ai를 통한 플레이어 따라다니기 타겟

    public bool isDead = false; // 죽음 판단 변수

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;

    void Awake() 
    {
    }

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();

        isDead = false ;
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        nav = GetComponent<NavMeshAgent>();
    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }
    //플레이어와 충돌시 ai nav와 물리작용으로 이동 방해 방지

    void Update()
    {
        target = GameObject.Find("Player").transform;
        nav.SetDestination(target.position);
    }
    //플레이어 따라다니는 ai
}
