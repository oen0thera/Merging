using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mob : MonoBehaviour
{
    private int maxHP = 200;
    private int curHP = 200;
    private bool isChase; //���� �����ϰԸ���� ������
    [SerializeField] private Transform target;

    Rigidbody rigid;
    BoxCollider boxCollider;
    NavMeshAgent nav;
    Animator ani;
    
    void ChaseStart()
    {
        isChase = true;
        ani.SetBool("isRun", true);
    }
    private void Awake()
    {   
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        ani = GetComponentInChildren<Animator>();
        
        nav = GetComponent<NavMeshAgent>();

        Invoke("ChaseStart", 3); //���� ���� �� 3�ʵ� �÷��̾� ����
    }
    private void Update()
    {
        if(curHP <= 0)
        {
            isChase = false;
            ani.SetTrigger("Die");

            Destroy(gameObject, 3);
        }
        if(isChase)
            nav.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            curHP -= bullet.damage;
            StartCoroutine(OnDamage());
        }
    }

    IEnumerator OnDamage()
    {

        yield return new WaitForSeconds(0.1f);

      
    }
}
