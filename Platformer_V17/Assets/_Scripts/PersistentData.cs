using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour {
//this class holds all persistent data throughout the scenes.
    public static PersistentData instance = null;

    [HideInInspector]
        public int lives;
    [HideInInspector]
        public int coins;
    [HideInInspector]
        public int completedLevels;

    private void Awake()
    {
        singleton();
    }

    private void Start()
    {
        completedLevels = 1;
    }

    private void singleton()
    {
        // Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }
}
