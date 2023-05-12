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
    
    [Header("Character Attributes")]
    private Rigidbody2D rb;
    private Transform aimPos;
    private Vector3 mousePos;
    private SpriteRenderer charSprite;
    [SerializeField] private Sprite leftCharSprite;
    [SerializeField] private Sprite rightCharSprite;
    [SerializeField] private Sprite upCharSprite;
    [SerializeField] private Sprite downCharSprite;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        aimPos = transform.Find("GunSprite");
        charSprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Aim();
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

    private void Aim()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = mousePos - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        aimPos.eulerAngles = new Vector3(0, 0, angle);

        if(angle > 90 || angle < -90)
        {
            charSprite.sprite = rightCharSprite;
        }
        else
        {
            charSprite.sprite = leftCharSprite;
        }
    }
}
