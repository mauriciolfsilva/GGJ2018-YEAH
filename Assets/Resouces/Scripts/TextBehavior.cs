using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBehavior : MonoBehaviour {

	void Start ()
    {
        t =  this.gameObject.GetComponent<Text>();
        i = 0;
        space = false;
        finish = false;
        t.text = "";
        textSpeed = .2f;
        StartCoroutine("Write");
	}
    [SerializeField]
    private string[] roteiro;
    private int i;
    private bool finish;
    private bool space;
    private float textSpeed;
    private Text t;


    void Update ()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            textSpeed = 0;
        }

        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            textSpeed = .2f;
        }

        if(finish)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                finish = false;
                space = true;
            }
        }

        if(space)
        {
            space = false;
            if (i < roteiro.Length)
            {
                t.text = "";
                StartCoroutine("Write");
            }
        }
	}

    IEnumerator Write()
    {
        foreach (char a in roteiro[i])
        {
            t.text += a;
            this.gameObject.GetComponent<Text>().text = t.text;
            yield return new WaitForSeconds(textSpeed);
        }
        finish = true;
        i += 1;
    }
}
