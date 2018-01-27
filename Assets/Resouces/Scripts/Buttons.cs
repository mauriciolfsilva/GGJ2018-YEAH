using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	void Start () {
		
	}
	

    public void ChangeScene()
    {
        switch (this.gameObject.name)
        {
            case "Game":
                SceneManager.LoadScene(2);
                break;
            case "Creditos":
                SceneManager.LoadScene(1);
                break;
            case "Quit":
                Application.Quit();
                break;
            default:
                SceneManager.LoadScene(0);
                break;
        }
    }



	void Update () {
		
	}
}
