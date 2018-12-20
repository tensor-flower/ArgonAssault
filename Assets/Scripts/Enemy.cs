using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosionFX;
    BoxCollider myCollider;

    private void Start()
    {
        myCollider = gameObject.AddComponent<BoxCollider>();
        myCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(gameObject.name + " collided with " + other.gameObject.name);
        //explosionFX = transform.Find("Explosion").gameObject;
        //explosionFX.SetActive(true);
        Instantiate(explosionFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
