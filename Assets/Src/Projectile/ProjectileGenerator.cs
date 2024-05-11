using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    public List<Pooler> projectiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject SpawnProjectile(int index, Vector2 position)
    {
        GameObject res = projectiles[index].Get();
        res.transform.position = position;
        res.SetActive(true);
        return res;
    }

    public GameObject SpawnProjectile(int index, Vector2 position, Vector2 direction)
    {
        GameObject res = SpawnProjectile(index, position);
        res.transform.up = direction.normalized;
        return res;
    }

    public GameObject SpawnProjectile(int index, Vector2 position, float direction)
    {
        GameObject res = SpawnProjectile(index, position);
        res.transform.eulerAngles = Vector3.forward * direction;
        return res;
    }

    
}
