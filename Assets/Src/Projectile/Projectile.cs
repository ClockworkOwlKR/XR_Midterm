using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage;
    public float speed;
    public float accel;
    public float lifespan;

    List<GameObject> exceptions = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        speed = Mathf.Max(speed + accel*Time.deltaTime, 0);
        lifespan -= Time.deltaTime;

        if(speed < 0 || lifespan < 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Entity entity = other.gameObject.GetComponent<Entity>();
        if (entity != null && !exceptions.Contains(other.gameObject))
        {
            entity.ModifyHitpoint(-damage);
            gameObject.SetActive(false);
        }
    }

    public void Initialize(int dmg, float spd, float acc)
    {
        exceptions.Clear();
        damage = dmg;
        speed = spd;
        accel = acc;
    }

    public void SetRange(float range) {
        // d = v0 t + (a/2)t^2
        // (a/2)t^2 + v0 t - d = 0
        // t = (-v0 + sqrt(v0^2 + 2ad))/a
        if (Mathf.Approximately(accel, 0)) {
            lifespan = range / speed;
        }
        else
        {
            lifespan = (Mathf.Sqrt(Mathf.Pow(speed, 2) + 2 * accel * range) - speed) / accel;
        }
    }
    public void SetLifespan(float len)
    {
        lifespan = len;
    }
    public void AddException(GameObject obj)
    {
        exceptions.Add(obj);
    }
}
