using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    float rotationSpeed = 5f;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        if (GameBehaviour.instance.paused == false)
        {
            gameObject.transform.Rotate(0, rotationSpeed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.SetActive(false);
        GameBehaviour.instance.addCoin();
    }
}
