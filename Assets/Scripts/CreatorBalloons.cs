using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorBalloons : MonoBehaviour
{
    [SerializeField]  GameObject prefabBalloon;
    private  StartPositionSetter startPositionSetter;
    public float offsetX;

    private void Awake()
    {
        initialize();

    }
   
    public GameObject CreateBalloone()
    {
        return Instantiate(prefabBalloon, startPositionSetter.SetToStartPosition(offsetX), Quaternion.identity);
    }
    public void initialize()
    {
        startPositionSetter = GetComponent<StartPositionSetter>();
        offsetX = prefabBalloon.GetComponent<BoxCollider>().size.x;
    }
}
