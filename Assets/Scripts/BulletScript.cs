using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 70f;

    private Transform target;

    public void Seek(Transform _target)
    {
        target = _target;
    }


    private void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 dir = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        Debug.Log(Time.deltaTime);
    }

    private void HitTarget()
    {
        Debug.Log("HIT!!!");
        Destroy(gameObject);
    }
}
