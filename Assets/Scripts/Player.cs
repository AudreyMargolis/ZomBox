using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool swinging = false;
    public bool alive = true;

    public Rigidbody rb;
    public Camera cam;
    public Animator animator;


    //weapon variables
    public int currentWeapon = 0;
    public GameObject[] weapons;
    public GameObject[] bulletSpawns;
    public GameObject[] bullets;
    public bool hasPistol = false, hasAuto = false, hasShotgun = false, hasSMG = false, hasRocketLauncher = false, hasMinigun = false, hasGrenadeLauncher = false, hasMeleeUpgrade = false, hasThrowable = false;
    public int gunType = 0; // 0 = unarmed, 1 = pistol, 2 = automatic,
    public int meleeType = 0;

    public bool canFire = true;
    public float pistolFireRate;
    public float shotgunFireRate;
    public float autoFireRate;
    public float smgFireRate;
    public float rocketFireRate;
    public float grenadeFireRate;
    public float oneHandedRate;
    public float twoHandedRate;






    public int hp;

    Vector3 movement;
    float angle;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        gunType = 0;
        animator.SetInteger("WeaponType_int", gunType);
        meleeType = 1;
        animator.SetInteger("MeleeType_int", meleeType);
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            #region Movement
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.z = Input.GetAxisRaw("Vertical");

            Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

            //Get the Screen position of the mouse
            Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

            //Get the angle between the points
            angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            if (Input.GetKeyDown(KeyCode.LeftShift))
                moveSpeed = 7f;
            if (Input.GetKeyUp(KeyCode.LeftShift))
                moveSpeed = 5f;
            #endregion

            #region WeaponChanging
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (hasPistol)
                {
                    gunType = 1;
                    weapons[currentWeapon].SetActive(false);
                    currentWeapon = 3;
                    weapons[currentWeapon].SetActive(true);
                    animator.SetInteger("WeaponType_int", gunType);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                gunType = 0;
                weapons[currentWeapon].SetActive(false);
                currentWeapon = 0;
                weapons[currentWeapon].SetActive(true);
                animator.SetInteger("WeaponType_int", gunType);
            }

            #endregion
            if (Input.GetMouseButtonDown(0))
            {
                if (gunType == 0)
                    StartCoroutine("OneHandedSwing");
                else if (gunType == 1)
                {
                    if (canFire)
                        StartCoroutine("PistolFire");
                }
            }
        }
        if (hp <= 0)
            Die();
    }
    void FixedUpdate()
    {
        if (alive)
        {
            if (!swinging)
            {
                if (movement != Vector3.zero)
                    animator.SetFloat("Speed_f", moveSpeed * 0.1f);
                else
                    animator.SetFloat("Speed_f", 0f);
                rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
            }
            if (gunType <= 1 || gunType == 12)
                transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 90f, 0f));
            else
                transform.rotation = Quaternion.Euler(new Vector3(0f, -angle - 45f, 0f));

            //animator.SetInteger("WeaponType_int", gunType);
        }
    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
         return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
     }

    public void Pickup(int weapon)
    {
        switch(weapon)
        {
            case 0: // Revolver
                {
                    if (!hasPistol)
                    {
                        hasPistol = true;
                        gunType = 1;
                        weapons[currentWeapon].SetActive(false);
                        currentWeapon = 3;
                        weapons[currentWeapon].SetActive(true);
                        animator.SetInteger("WeaponType_int", gunType);
                    }
                    else
                    {
                        //add ammo
                    }
                    break;
                }
            default:
                break;
        }
    }
    public void TakeDamage(int dmg){
        hp -= dmg;
        
    }
    void Die()
    {
        alive = false;
        animator.SetBool("Death_b", true);
       // Destroy(this.gameObject);
    }
    IEnumerator OneHandedSwing()
    {
        swinging = true;
        gunType = 12;
        animator.SetFloat("Speed_f", 0f);
        animator.SetInteger("WeaponType_int", gunType);
        yield return new WaitForSeconds(oneHandedRate);
        gunType = 0;
        animator.SetInteger("WeaponType_int", gunType);
        swinging = false;
    }
    IEnumerator PistolFire()
    {
        canFire = false;
        animator.SetBool("Shoot_b", true);
        Instantiate(bullets[0], bulletSpawns[0].transform.position, bulletSpawns[0].transform.rotation);
        yield return new WaitForSeconds(pistolFireRate);
        animator.SetBool("Shoot_b", false);
        canFire = true;
    }


}