using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour
{
    static int score = 0;

    public static void AddScore(int amount) {
        score += amount;
    }
    public static int GetScore()
    {
        return score;
    }

    public static void StartGame() {
        score = 0;
        SceneManager.LoadScene("Main");
    }

    public static void EndGameDefeat()
    {
        Debug.Log("EndGameDefeat");
        SceneManager.LoadScene("GameDefeat");
    }

    public static void EndGameVictory()
    {
        SceneManager.LoadScene("GameEnd");
    }
}
