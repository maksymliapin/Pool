using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonMoover : MonoBehaviour
{
    public float speed = 2;
    public float finishPosition;
    private bool isRihgt;
    private bool isLeft;
    private Camera cam;
    private float offsetX;
    private void Awake()
    {
        initialize();
    }
    private void Start()
    {
        if (transform.position.x < 0)
        {
            isLeft = true;
        }
        if (transform.position.x > 0)
        {
            isRihgt = true;
        }

    }
    private void Update()
    {
        Move();
    }
    public void Move()
    {
        if (isLeft)
        {
            finishPosition = (cam.orthographicSize * cam.aspect) + offsetX;
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= finishPosition)
            {
                PoolContainer.instance.AddObjectToPool(gameObject);
            }
        }
        if (isRihgt)
        {
            finishPosition = (-cam.orthographicSize * cam.aspect) - offsetX;
            transform.position -= Vector3.right * speed * Time.deltaTime;
            if (transform.position.x <= finishPosition)
            {
                PoolContainer.instance.AddObjectToPool(gameObject);
            }
        }
    }
    public void initialize()
    {
        cam = Camera.main;
        offsetX = GetComponent<BoxCollider>().size.x;
    }

}
