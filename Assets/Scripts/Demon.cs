using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy
{
    // Start is called before the first frame update

    public GameObject fireBallSpawn;
    public GameObject fireBall;


    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();
    }
    public void Fire()
    {
        if (canFire)
        {
            Instantiate(fireBall, fireBallSpawn.transform.position, fireBallSpawn.transform.rotation);
            canFire = false;
            StartCoroutine(waitToFire());
        }
    }
    
}
