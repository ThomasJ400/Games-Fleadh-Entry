using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehaviour : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D collider)
	{
		//    Debug.Log("Hit");
		if (collider.gameObject.CompareTag("Player"))
		{
            GameBehaviour.instance.lifeDecrease();
			Destroy(this.gameObject);
		}
	}
}
