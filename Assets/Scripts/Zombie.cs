using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public GameObject player;
    public float agroRange = 10f;
    public float attackRange = 5f;
    public int hp;


    bool attacking = false;
    bool followPlayer = false;
    bool alive = true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            if (!followPlayer)
            {
                if (Vector3.Distance(transform.position, player.transform.position) < agroRange)
                {
                    followPlayer = true;
                }

            }
            else
            {

                if (attacking == false)
                {
                    animator.SetBool("Walking_b", true);
                    navMeshAgent.SetDestination(player.transform.position);
                }
            }
            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                if (attacking == false)
                    StartCoroutine("Attack");
            }
            if (hp <= 0)
                StartCoroutine("Die");
        }

    }
    public void hit(int dmg)
    {
        StartCoroutine("hitReaction");
        hp -= dmg;
    }
    IEnumerator hitReaction()
    {
        followPlayer = false;
        yield return new WaitForSeconds(0.5f);
        followPlayer = true;
    }
    IEnumerator Attack()
    {
        attacking = true;
        animator.SetBool("Attacking_b", attacking);
        yield return new WaitForSeconds(1f);
        attacking = false;
        animator.SetBool("Attacking_b", attacking);
    }
    IEnumerator Die()
    {
        alive = false;
        animator.SetBool("Dead_b", true);
        yield return new WaitForSeconds(30f);
        Destroy(this.gameObject);
    }
}
