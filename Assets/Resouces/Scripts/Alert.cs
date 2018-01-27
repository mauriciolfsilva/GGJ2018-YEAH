using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool dir = false;
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x > this.gameObject.transform.position.x) dir = true;
            GameObject.FindGameObjectWithTag("Guard").GetComponent<EnemyBehavior>().Alert(dir, collision.transform.position);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Debug.Log("FUGIU");
    }
}
