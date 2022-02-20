using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   [SerializeField] private int score = 0;
   [SerializeField] private int lives = 3;
    
    public void AddLives(int value)
    {
        lives += value;
        if (lives <=0)
        {
            Debug.Log("Game Over");
            lives = 0;
        }
        Debug.Log("Lives = " + lives);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score =" + score);
    }
}
