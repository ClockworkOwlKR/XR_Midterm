using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public GameObject cam;
    public float tileX = 1, tileY = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        Vector2 cam_pos = cam.transform.position;
        Vector2 deviation = cam_pos - pos;
        while(Mathf.Abs(cam_pos.x - pos.x) > tileX)
        {
            pos.x += tileX * Mathf.Sign(deviation.x);
        }
        while(Mathf.Abs(cam_pos.y - pos.y) > tileY)
        {
            pos.y += tileY * Mathf.Sign(deviation.y);
        }
        Debug.Log(pos);
        transform.position = pos;
    }
}
