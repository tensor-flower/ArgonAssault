//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //config params
    [SerializeField] GameObject explosionFX;
    [SerializeField] int destroyScore;

    //cache
    BoxCollider myCollider;
    bool isHit = false;
    ScoreBoard scoreBoard;

    private void Start()
    {
        myCollider = gameObject.AddComponent<BoxCollider>();
        myCollider.isTrigger = false;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(gameObject.name + " collided with " + other.gameObject.name);
        //explosionFX = transform.Find("Explosion").gameObject;
        //explosionFX.SetActive(true);
        if(!isHit)
        {
            isHit = true;         
            scoreBoard.AddScore(destroyScore);  
            GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }

}
