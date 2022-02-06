using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolContainer : MonoBehaviour
{
    public static PoolContainer instance;
    public int amount = 5;
    private StartPositionSetter startPositionSetter;
    private CreatorBalloons CreatorBalloons;
    private float width;
    private float offsetX;

    private List<GameObject> pool = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        initialize();
    }

    private void Start()
    {
        Play();
    }
    private void Update()
    {
        RemoveObjectToPool();
        
        Reuse();
    }
    public void AddObjectToPool(GameObject instance)
    {
        if (instance.activeInHierarchy )
        {
            instance.SetActive(false);
            pool.Add(instance);
        }
    }
    public void RemoveObjectToPool()
    {
        for (int i = pool.Count - 1; i >= 0; i--)
        {
            if (pool[i].activeInHierarchy)
            {
                pool.Remove(pool[i]);
               
            }
        }
    }
    public void Reuse()
    {
        foreach (var item in pool)
        {
           
            if (item.transform.position.x >= width || item.transform.position.x <= -width && item.activeInHierarchy == false)
            {
                item.transform.position = startPositionSetter.SetToStartPosition(offsetX);
                item.SetActive(true);
            }
        }
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(0.1f, 5.1f));
        var instance = CreatorBalloons.CreateBalloone();
        instance.SetActive(false);
        pool.Add(instance);
        instance.SetActive(true);
    }
    public void initialize()
    {
        startPositionSetter = GetComponent<StartPositionSetter>();
        CreatorBalloons = GetComponent<CreatorBalloons>();
        offsetX = GetComponent<CreatorBalloons>().offsetX;
        width = startPositionSetter.width;
    }
    private void Play()
    {
        if (amount > 0)
        {
            for (int i = 0; i < amount; i++)
            {
                StartCoroutine("Spawn");
            }
        }
    }
}

