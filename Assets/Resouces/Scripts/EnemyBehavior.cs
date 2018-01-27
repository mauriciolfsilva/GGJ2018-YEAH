using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    private Vector3 startPoint;
    [SerializeField]
    private float speed_x;

    private Vector3 pos;
    private bool hunting;
    private bool returning;
    private bool dir;

    public void Alert(bool dire, Vector3 tPos)
    {
        hunting = true;
        dir = dire;
        pos = tPos;
    }

    void Move ()
    {
        this.gameObject.transform.position += new Vector3(speed_x*Time.deltaTime, 0, 0);

        if (this.gameObject.transform.position.x > startPoint.x + 2)
        {
            this.gameObject.transform.position = new Vector3(startPoint.x + 2, startPoint.y, startPoint.z);
            speed_x *= -1;
        }

        if (this.gameObject.transform.position.x < startPoint.x - 2)
        {
            this.gameObject.transform.position = new Vector3(startPoint.x - 2, startPoint.y, startPoint.z);
            speed_x *= -1;
        }

    }

    void Hunt()
    {
        if (dir)
        {
            if (this.gameObject.transform.position.x < pos.x)
            {
                this.gameObject.transform.position += new Vector3(2*Mathf.Abs(speed_x) * Time.deltaTime, 0, 0);
            }
            else
            {
                returning = true;
            }
        }

        else
        {
            if (this.gameObject.transform.position.x > pos.x)
            {
                this.gameObject.transform.position -= new Vector3(2*Mathf.Abs(speed_x) * Time.deltaTime, 0, 0);
            }
            else
            {
                returning = true;
            }
        }
    }

    void ReturnPos()
    {
        if (this.gameObject.transform.position.x < startPoint.x) this.gameObject.transform.position += new Vector3(Mathf.Abs(speed_x) * Time.deltaTime, 0, 0);
        if (this.gameObject.transform.position.x > startPoint.x) this.gameObject.transform.position += new Vector3(Mathf.Abs(speed_x) * Time.deltaTime, 0, 0);

        if(Mathf.Abs(this.gameObject.transform.position.x - startPoint.x) < 0.2f)
        {
            this.gameObject.transform.position = new Vector3(startPoint.x, startPoint.y, startPoint.z);
            returning = false;
            hunting = false;
        }
    }

	void Start ()
    {
        startPoint = this.gameObject.transform.position;
        hunting = false;
        returning = false;
	}

    void Update ()
    {
        if (!hunting) Move();
        if (hunting && !returning) Hunt();
        if (returning) ReturnPos();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Debug.Log("MORTO");
    }
}