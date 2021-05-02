using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public int dmg;
    public Rigidbody rb;
    public float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
       // GameObject[] enemies = GameObject.FindObjectsOfType<Enemy>();
        //Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        rb.AddForce(transform.forward * bulletSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            other.gameObject.GetComponent<Player>().TakeDamage(dmg);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
