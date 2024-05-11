using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Detonate(other.gameObject.GetComponent<Player>());
        }
    }

    void Detonate(Entity target)
    {
        target.ModifyHitpoint(-damage);
        gameObject.SetActive(false);
    }
}
