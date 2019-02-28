using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    float rotationSpeed = 5f;
    //ParticleSystem particleSystem;

    private void Awake()
    {
        //particleSystem = this.gameObject.GetComponent<ParticleSystem>();  
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
        //Debug.Log("You hit a coin");
        //particleSystem.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.SetActive(false);
        //Destroy(gameObject,1f);

        GameBehaviour.instance.addCoin();
    }
}
