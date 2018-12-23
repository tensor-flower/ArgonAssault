//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //config params
    [SerializeField] GameObject explosionFX;
    [SerializeField] int destroyScore;
    [SerializeField] int hitPoint;

    //cache
    BoxCollider myCollider;
    bool isAlive = true;
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
        DecreaseHitPoint();
        //explosionFX = transform.Find("Explosion").gameObject;
        //explosionFX.SetActive(true);
        if(!isAlive)
        {      
            scoreBoard.AddScore(destroyScore); //TODO sometimes still double add score
            GameObject explosion = Instantiate(explosionFX, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }

    void DecreaseHitPoint(){
        hitPoint -= 1;
        if(hitPoint<=0){
            isAlive = false;
        }
    }

}
