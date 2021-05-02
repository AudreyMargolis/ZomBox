using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public Rigidbody rb;
    public int dmg;
    public float bulletSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("Player");
         Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        rb.AddForce(transform.forward * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Zombie")
            other.gameObject.GetComponent<Zombie>().hit(dmg);
        Destroy(this.gameObject);
    }
}
