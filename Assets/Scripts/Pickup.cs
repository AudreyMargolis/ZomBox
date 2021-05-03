using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public enum pickupType {REVOLVER, AK47, SHOTGUN, SMG}
    public pickupType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            player.Pickup((int)type);

            Destroy(this.gameObject);
        }
    }
}
