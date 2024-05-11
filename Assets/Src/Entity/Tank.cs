using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tank : Entity
{
    public ProjectileLauncher MainGun;
    public GameObject GunTurret;

    public float MaxSpeed;
    public float Accel;
    public float TurnRate;

    protected float Speed = 0;
    protected float Bearing = 0;

    protected Rigidbody2D Body;

    protected Vector2 Control = new Vector2();
    protected bool FireControl = true;

    // Start is called before the first frame update
    protected void Start()
    {
        base.Start();
        Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected void Update()
    {
        Move();
        Fire();
    }

    void Move()
    {
        Bearing = Mathf.Repeat(Bearing - Control.x * TurnRate * Time.deltaTime, 360);
        transform.eulerAngles = Vector3.forward * Bearing;

        float TargetSpeed = Control.y * MaxSpeed;
        float Diff = TargetSpeed - Speed;
        float AccelFraction = Accel * Time.deltaTime;

        if (Mathf.Abs(Diff) > AccelFraction)
        {
            Speed += AccelFraction * Mathf.Sign(Diff);
        }
        else
        {
            Speed = TargetSpeed;
        }
        Body.velocity = transform.up * Speed;
        Debug.Log(Body.velocity);
    }

    void Fire()
    {
        if (FireControl)
        {
            MainGun.Fire();
        }
    }
    protected void LookAtTarget(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)GunTurret.transform.position).normalized;
        GunTurret.transform.up = direction;
    }
}
