using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointBehavior : MonoBehaviour {
    public static checkpointBehavior instance = null;
    public GameObject[] collectibles;
    GameObject spawnPoint;
    public Sprite checkpointOn;
    bool checkpoint = false;
    [HideInInspector]
    public float checkedTime;

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        spawnPoint = GameObject.Find("World Spawn");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (checkpoint == false)
        {
            checkedTime = TimerBehaviour.instance.timer;
            //remove collectibles
            changeIcon();
            checkpoint = true;

            checkpointStart();
            //set checkpoint hit to true
            GameBehaviour.instance.checkpointHit = true;
            //changeSprite
            
        }
    }

    public void changeIcon()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = checkpointOn;
    }

    public void checkpointStart()
    {
        //spawnPoint.transform.position = this.transform.position;
        for (int i = 0; i < collectibles.Length; i++)
        {
            collectibles[i].SetActive(false);
        }
    }
}
