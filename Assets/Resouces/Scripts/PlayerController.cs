using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed_x;
    [SerializeField]
    private float speed_y;


    void Move ()
    {
        #region MoveHorizontal
        if (Input.GetKey(KeyCode.A)) this.gameObject.transform.position -= new Vector3(speed_x, 0, 0);
        if (Input.GetKey(KeyCode.D)) this.gameObject.transform.position += new Vector3(speed_x, 0, 0);
        #endregion

        #region MoveBackground

        if(Input.GetKey(KeyCode.S))
        {
            if (this.gameObject.transform.localScale.x < 10)
            {
                this.gameObject.transform.position -= new Vector3(0, speed_y / 2, 0);
                this.gameObject.transform.localScale += new Vector3(speed_y, speed_y, 0);
            }

            else
            {
                this.gameObject.transform.localScale = new Vector3(10, 10, 1);
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -2, this.gameObject.transform.position.z);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (this.gameObject.transform.localScale.x > 8)
            {
                this.gameObject.transform.position += new Vector3(0, speed_y / 2, 0);
                this.gameObject.transform.localScale -= new Vector3(speed_y, speed_y, 0);
            }

            else
                this.gameObject.transform.localScale = new Vector3(8, 8, 1);
        }

        #endregion
    }

    void Start ()
    {
	}
	
	void Update ()
    {
        Move();
	}
}
