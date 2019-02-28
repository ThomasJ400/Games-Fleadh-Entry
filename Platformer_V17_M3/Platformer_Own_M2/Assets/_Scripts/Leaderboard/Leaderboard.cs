using System;

[Serializable]

public class Leaderboard
{
    public string[] names;
    public int[] scores;
    
    public Leaderboard ()
    {
        names = new string[5];
        scores = new int[5];
        emptyBoard();
    }

    void emptyBoard()
    {
        for(int i = 0; i < 5; i++)
        {
            names[i] = "---";
            scores[i] = 0;
        }
    }

    int highestScore()
    {
        return scores[0];
    }

    int lowestScore()
    {
        return scores[4];
    }

    public void addScore(string nam, int newScore)
    {
        for(int i = 0;i<5;i++)
        {
            if(newScore>scores[i])
            {
                moveDown(i);
                scores[i] = newScore;
                names[i] = nam;
                i = 5;//to break the loop instantly.
            }
        }
    }

    public bool isHighScore(int score)
    {
        bool placed = false;
        if(score >= lowestScore())
        {
            placed = true;
        }
        return placed;
    }

    void moveDown(int index)
    {
        for(int i = scores.Length-1; i>index ;i--)
        {
            if(i!=index)
            {
                scores[i] = scores[i - 1];
                names[i] = names[i - 1];
            }
        }
    }
}
