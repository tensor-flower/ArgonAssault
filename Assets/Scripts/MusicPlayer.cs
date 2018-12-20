using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    int numberOfMusicPlayers;

    private void Awake()
    {
        numberOfMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if (numberOfMusicPlayers >= 2)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {DontDestroyOnLoad(gameObject); }
    }

}
