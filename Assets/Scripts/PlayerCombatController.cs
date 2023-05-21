using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    [Header("Bullet Attributes")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canFire;
    public float bulletLifetime = 4f;
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

    [SerializeField] private Sprite leftCharSprite;
    [SerializeField] private Sprite rightCharSprite;
    [SerializeField] private Sprite upCharSprite;
    [SerializeField] private Sprite downCharSprite;
    [SerializeField] private GameObject crossHair;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aimPos = transform.Find("GrabPoint");
        charSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Aim();
        Shoot();
    }

    private void Shoot()
    {
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

            // Destroy the bullet after a set amount of time
            Destroy(bullet, bulletLifetime);
        }
    }


}
