using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    GameObject parent;
    public enum colliderType {ARM, FIREBALL};
    public colliderType collType;
    void Start ()
    {
        parent = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(collType == colliderType.ARM)
        {
            if (parent.GetComponent<Demon>())
                parent.GetComponent<Demon>().OnChildCollision(other, "arm");
            if (parent.GetComponent<Enemy>())
                parent.GetComponent<Enemy>().OnChildCollision(other, "arm");
        }
        else if (collType == colliderType.FIREBALL)
        {
            if (parent.GetComponent<Demon>())
                parent.GetComponent<Demon>().Fire();
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (collType == colliderType.ARM)
        {
            if (parent.GetComponent<Demon>())
                parent.GetComponent<Demon>().OnChildCollision(other, "arm");
            if (parent.GetComponent<Enemy>())
                parent.GetComponent<Enemy>().OnChildCollision(other, "arm");
        }
        else if (collType == colliderType.FIREBALL)
        {
            if (parent.GetComponent<Demon>())
                parent.GetComponent<Demon>().Fire();
        }

    }
}
