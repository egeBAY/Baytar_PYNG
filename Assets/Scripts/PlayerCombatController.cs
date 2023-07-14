using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canFire;
    public float bulletLifetime = 3f;
    public float bulletSpeed = 10f;
    public float timeBetweenFiring;
    private float timer;

    [Space]
    [Header("Character Attributes")]
    private Rigidbody2D rb;
    private Transform aimPos;
    private Vector3 mousePos;
    private Animator animator;
    private SpriteRenderer charSprite;
    private Transform itemPos;
    public bool hasMeleeWeapon;
    public bool hasRangedWeapon;
    public GameObject crossHair;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aimPos = transform.Find("GrabPoint");
        charSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        itemPos = transform.Find("ItemSprite").transform;
    }

    private void Update()
    {
        AimAndShoot();
    }

    private void AimAndShoot()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        itemPos.eulerAngles = new Vector3(0, 0, angle);
        
        crossHair.transform.position = mousePos;


        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        
        if (Input.GetMouseButtonDown(0) && canFire)
        {   
            canFire = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = aimDir * bulletSpeed;
            bullet.transform.Rotate(0f, 0f, Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg);
            Destroy(bullet, bulletLifetime);
        }
    }


}
