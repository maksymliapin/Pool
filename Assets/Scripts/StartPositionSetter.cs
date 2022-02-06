using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPositionSetter : MonoBehaviour
{
    public float height;
    public float width;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    public Vector3 SetToStartPosition(float offset)
    {
        height = cam.orthographicSize;
        width = height * cam.aspect;
        var side = Random.Range(0, 2);
        if (side == 0)
        {
            return new Vector3(-width -offset, Random.Range(-height/2, height), 0);
        }
        else
        {
            return new Vector3(width + offset, Random.Range(-height/2, height), 0);
        }
    }
}

