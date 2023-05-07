using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class CameraFollower : MonoBehaviour
{
    private Transform targetTransform;

    public Vector2 minPos;
    public Vector2 maxPos;

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (transform.position != targetTransform.position)
        {
            Vector3 targetPos = new Vector3(targetTransform.position.x, targetTransform.position.y, transform.position.z);

            targetPos.x = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

            transform.position = Vector3.Lerp(transform.position, targetPos, 0.125f);
        }
    }
}
