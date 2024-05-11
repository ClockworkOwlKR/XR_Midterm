using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainGameMaster : MonoBehaviour
{
    public GameObject Player;

    public ProjectileGenerator projectileGenerator;

    public Vector2 StageRange;

    public int MineCount;
    public GameObject Mine;
    public int TankCount;
    public GameObject Tank;

    public static MainGameMaster GetMain()
    {
        return GameObject.FindGameObjectWithTag("GameManager").GetComponent<MainGameMaster>();
    }

    public Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-StageRange.x, StageRange.x), Random.Range(-StageRange.y, StageRange.y));
    }


    // Start is called before the first frame update
    void Start()
    {
        Deploy(Mine, MineCount);
        Deploy(Tank, TankCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deploy(GameObject obj, int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            GameObject temp = Instantiate(obj);
            temp.transform.position = GetRandomPosition();
        }
    }
}
