using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertGuard : MonoBehaviour {

	void Start ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool dir = false;
        if (collision.CompareTag("Player"))
        {
            if (collision.transform.position.x > this.gameObject.transform.position.x) dir = true;
            this.gameObject.GetComponentInParent<EnemyBehavior>().Alert(dir, collision.transform.position);
        }
    }


    void Update ()
    {
		
	}
}
