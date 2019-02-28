using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker{

    int score = 0;
    //int coinsGathered = 0;
    //float timeRemaining = 0;

    public ScoreTracker()
    {
        score = 0;
       // coinsGathered = 0;
        //timeRemaining = 0;
    }

    public void calculateScore(LevelScore ls)
    {
        score += (int)ls.timeRemaining * ls.coinsCollected;
        //Debug.Log("Current Score: " + score);
    }

    public void resetScore()
    {
        score = 0;
     //   coinsGathered = 0;
     //   timeRemaining = 0;
    }

  /*  public bool checkHighScore()
    {
        bool isHighScore = false;
        
        if(lb.isHighScore(score))
        {
            isHighScore = true;
        }

        return isHighScore;
    }
    */
    public int getScore()
    {
        return score;
    }
}
