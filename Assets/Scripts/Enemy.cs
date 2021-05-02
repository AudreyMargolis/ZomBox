using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject player;
    public GameManager gm; 
    public NavMeshAgent agent;

    public int hp = 50;
    public int dmg = 20;
    public int score;
    public float fireRate = 1.0f;
    public float attackRate = 0.5f;
    public bool canFire = true;
    public bool canAttack = true;
    public enum enemyType {ZOMBIE, DEMON};
    public enum enemyState {MOVING, ATTACKING, DYING};
    public enemyType type;
    public enemyState state;
    // Start is called before the first frame update
    public virtual void Start()
    {
        player = GameObject.Find("Player");
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        state = enemyState.MOVING;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if(state == enemyState.MOVING)
        {
            if (player)
                agent.SetDestination(player.transform.position);
        }
    }
     public void TakeDamage(int dmg){
        hp -= dmg;
        if(hp<=0)
            Die();
    }
    public void Die()
    {
        state = enemyState.DYING;
        gm.score += score;
        Destroy(this.gameObject);
    }
    public void Attack(Collider other)
    {
        if (canAttack)
        {
            state = enemyState.ATTACKING;
            other.gameObject.GetComponent<Player>().TakeDamage(dmg);
            canAttack = false;
            StartCoroutine(waitToAttack());
        }
    }
     public void OnChildCollision(Collider other, string collType)
    {
        if (collType == "arm")
        {
            Debug.Log("Hit Player");
         
            if (other.gameObject.GetComponent<Player>())
                Attack(other);
        }
    }
    public void OnChildCollisionStay(Collider other)
    {
        //Debug.Log("Hit Player");
        //if (other.gameObject.GetComponent<Player>())
           // other.gameObject.GetComponent<Player>().TakeDamage(dmg);
    }
    // need to make hit coroutine
    public IEnumerator waitToFire()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    public IEnumerator waitToAttack()
    {
        yield return new WaitForSeconds(attackRate);
        canAttack = true;
        state = enemyState.MOVING;
    }
}
