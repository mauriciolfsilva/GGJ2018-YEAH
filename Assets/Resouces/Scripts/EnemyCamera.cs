using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamera : MonoBehaviour {

    [SerializeField]
    private float turn_speed;

    void Turn()
    {
        this.gameObject.transform.Rotate(new Vector3(0,0,turn_speed*Time.deltaTime));
        if (this.gameObject.transform.eulerAngles.z > 90 && this.gameObject.transform.eulerAngles.z < 180)
        {
            Vector3 temp = new Vector3(0,0,90);
            Quaternion j = new Quaternion();
            j.eulerAngles = temp;
            this.gameObject.transform.rotation = j;
            turn_speed *= -1;
        }

        if(this.gameObject.transform.eulerAngles.z < 360 && this.gameObject.transform.eulerAngles.z > 270)
        {
            Vector3 temp2 = new Vector3(0, 0, 0);
            Quaternion j2 = new Quaternion();
            j2.eulerAngles = temp2;
            this.gameObject.transform.rotation = j2;
            turn_speed *= -1;
        }
    }


	void Start ()
    {
		
	}
	
	void Update ()
    {
        Turn();
	}
}
