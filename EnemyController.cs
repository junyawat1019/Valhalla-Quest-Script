using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour 
{
    private Animator anim;
    NavMeshAgent agent;
    Transform target;
    public float lookRadius;
    public float attackRadius;
    public bool isAttack = false;
    public static EnemyController instance;

    void Start () 
    {
        target = vThirdPersonController.instance.transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            anim.SetBool("IsWalk", true);
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        else
        {
            anim.SetBool("IsWalk", false);
        }
        if (distance <= attackRadius)
        {
            anim.SetBool("IsWalk", false);
            isAttack = true;
            Invoke("Attack", 1f);
            GetComponent<Animator>().SetTrigger("IsAttack");
        }
	}

    void Attack()
    {
        if (isAttack == true)
        {
            isAttack = false;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
