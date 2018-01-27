using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    private float speed_x;
    [SerializeField]
    private float speed_y;
    private bool returning;
    private bool canHide;

    void ReturnSize()
    {
        if (this.gameObject.transform.localScale.x < 10)
        {
            this.gameObject.transform.position -= new Vector3(0, (speed_y / 2)*Time.deltaTime*20, 0);
            this.gameObject.transform.localScale += new Vector3(speed_y * Time.deltaTime*20, speed_y * Time.deltaTime*20, 0);
        }

        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
            canHide = false;
            returning = false;
            this.gameObject.transform.localScale = new Vector3(10, 10, 1);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, -2, this.gameObject.transform.position.z);
        }
    }

    void Move ()
    {
        #region MoveHorizontal
        if (Input.GetKey(KeyCode.A) && this.gameObject.transform.position.x > -8.2f) this.gameObject.transform.position -= new Vector3(speed_x, 0, 0);
        if (Input.GetKey(KeyCode.D) && this.gameObject.transform.position.x < 8.2f) this.gameObject.transform.position += new Vector3(speed_x, 0, 0);
        #endregion

        #region MoveBackground

        if (canHide)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                returning = true;
            }

            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                if (this.gameObject.transform.localScale.x > 9)
                {
                    this.gameObject.transform.position += new Vector3(0, speed_y / 2, 0);
                    this.gameObject.transform.localScale -= new Vector3(speed_y, speed_y, 0);
                }

                else
                    this.gameObject.transform.localScale = new Vector3(9, 9, 1);
            }
        }

        #endregion
    }

    void Start ()
    {
        
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Covert"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Input.GetKey(KeyCode.W))
        {
            if (collision.CompareTag("Covert")) canHide = false;
        }
    }


    void Update ()
    {
        if (!returning) Move();
        if (returning) ReturnSize();
	}
}
