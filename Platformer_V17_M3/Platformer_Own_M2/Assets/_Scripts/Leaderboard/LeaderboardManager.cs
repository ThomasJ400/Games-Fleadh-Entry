using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public Text[] names;
    public Text[] scores;
    Leaderboard leaderboard;

    void Start()
    {
        
        getValues();
    }

    void getValues()
    {
        for (int i = 0; i < PersistenceManager.instance.lb.names.Length; i++)
        {
            names[i].text = PersistenceManager.instance.lb.names[i];
            scores[i].text = "" + PersistenceManager.instance.lb.scores[i];
        }
    }
}
