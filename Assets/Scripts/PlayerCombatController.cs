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
    public bool hasMeleeWeapon;
    public bool hasRangedWeapon;
    public GameObject crossHair;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aimPos = transform.Find("GrabPoint");
        charSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        AimAndShoot();
    }

    private void AimAndShoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = mousePos;
        mousePos.Normalize();


        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        
        if (Input.GetButtonDown("Fire1") && canFire)
        {   
            canFire = false;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<CharacterBullet>().bulletVelocity = mousePos * bulletSpeed;
            bullet.transform.Rotate(0f, 0f, Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg);
            Destroy(bullet, bulletLifetime);
        }
    }


}
