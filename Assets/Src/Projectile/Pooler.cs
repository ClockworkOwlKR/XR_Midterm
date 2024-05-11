using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Pooler : MonoBehaviour
{
    public int InitialPoolSize;
    public int Batch;

    public GameObject Object;

    List<GameObject> Pool = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsTrue(Batch > 0);
        AddToPool(InitialPoolSize);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject AddToPool(int amount)
    {
        Assert.IsTrue(amount > 0);
        GameObject temp = null;
        for (int i = 0; i < amount; i++) {
            temp = Instantiate(Object);
            temp.SetActive(false);
            Pool.Add(temp);
        }
        return temp;
    }

    public GameObject Get()
    {
        foreach(GameObject obj in Pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return AddToPool(Batch);
    }
}
