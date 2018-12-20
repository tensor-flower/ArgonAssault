using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	void Start () {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadStart", 2f);
        }
	}
	
	void Update () {
		
	}

    void LoadStart()
    {
        SceneManager.LoadScene(1);
    }
}
