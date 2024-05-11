using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Tank
{
    public float AttackRange;
    public float MovementTolerance;
    public float AngularTolerance;

    MainGameMaster Main;

    Vector2 targetPos;

    // Start is called before the first frame update
    void Start()
    {
        Main = MainGameMaster.GetMain();
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPos = Main.Player.transform.position;
        LookAtTarget(playerPos);

        float AngularDiff = Vector2.SignedAngle(transform.up, targetPos - (Vector2)transform.position);
        Control = new Vector2(-Mathf.Sign(AngularDiff), 1);
        if(Mathf.Abs(AngularDiff) < AngularTolerance)
        {
            Control.x = 0;
        }
        FireControl = Vector2.Distance(playerPos, transform.position) <= AttackRange;
        
        base.Update();

        if(Vector2.Distance(transform.position, targetPos) <= MovementTolerance ) {
            targetPos = Main.GetRandomPosition();
        }
    }
    protected override void Die()
    {
        GameManager.AddScore(1);
        if (GameManager.GetScore() >= Main.TankCount)
        {
            GameManager.EndGameVictory();
        }
        gameObject.SetActive(false);
    }
}
