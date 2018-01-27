using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    private float speed = 0.5f;
    private Color c;
    void Start ()
    {
        c = this.gameObject.GetComponent<Image>().color;
    }
	
	void Update ()
    {
        c.a -= speed * Time.deltaTime;
        this.gameObject.GetComponent<Image>().color = c;
        if (c.a <= 0)
        {            
            Destroy(this.gameObject);
        }
	}
}
