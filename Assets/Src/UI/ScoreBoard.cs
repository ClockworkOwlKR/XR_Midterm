using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    MainGameMaster Main;
    TextMeshProUGUI Display;
    // Start is called before the first frame update
    void Start()
    {
        Main = MainGameMaster.GetMain();
        Display = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Display.text = "Destroy All\n" + GameManager.GetScore() + " / " + Main.TankCount;
    }
}
