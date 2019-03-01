using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker{

    int score = 0;
    public ScoreTracker()
    {
        score = 0;
    }

    public void calculateScore(LevelScore ls)
    {
        score += (int)ls.timeRemaining * ls.coinsCollected;
    }

    public void resetScore()
    {
        score = 0;
    }

    public int getScore()
    {
        return score;
    }
}
