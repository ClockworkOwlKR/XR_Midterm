using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected int HitPoint;
    public int MaxHitPoint;
    // Start is called before the first frame update
    protected void Start()
    {
        HitPoint = MaxHitPoint;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void Die() {}


    public virtual int ModifyHitpoint(int amount)
    {
        HitPoint += amount;
        if (HitPoint > MaxHitPoint)
        {
            HitPoint = MaxHitPoint;
        }
        else if (HitPoint <= 0)
        {
            HitPoint = 0;
            Die();
        }
        return HitPoint;
    }
}
