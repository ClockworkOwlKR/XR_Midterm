using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject MainBody;
    public GameObject Muzzle;
    public int ProjectileIndex;
    public int Damage;
    public float Speed;
    public float Acceleration;
    public float RateOfFire;
    public bool UseLifetime;
    public float Longevity;
    ProjectileGenerator generator;

    float Cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        generator = MainGameMaster.GetMain().projectileGenerator;
    }

    // Update is called once per frame
    void Update()
    {
        if(Cooldown >= 0)
        {
            Cooldown -= Time.deltaTime;
        }
    }

    public bool Fire()
    {
        if(Cooldown < 0)
        {
            Transform tf = Muzzle ? Muzzle.transform : transform;
            GameObject obj = generator.SpawnProjectile(ProjectileIndex, tf.position, tf.up);
            Projectile proj = obj.GetComponent<Projectile>();
            proj.Initialize(Damage, Speed, Acceleration);
            if (MainBody)
            {
                proj.AddException(MainBody);
            }
            if(UseLifetime)
            {
                proj.SetLifespan(Longevity);
            }
            else
            {
                proj.SetRange(Longevity);
            }
            Cooldown = RateOfFire;
            return true;
        }
        return false;
    }
}
