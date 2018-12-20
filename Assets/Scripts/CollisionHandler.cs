using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] float levelLoadDelay = 1f;
    GameObject explosionVFX;

	void Start () {
        explosionVFX = transform.Find("Explosion").gameObject;
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player triggered with " + other.gameObject.name);
        //GetComponent<ParticleSystem>().Play();
        //GameObject explosion = Instantiate(explosionVFX, transform.position, transform.rotation) as GameObject;
        //GameObject explosion = Instantiate(explosionVFX);
        //explosion.transform.SetParent(gameObject.transform, true);
        //Destroy(explosion, 0.5f);
        explosionVFX.SetActive(true);
        gameObject.SendMessage("Freeze");
        Invoke("ReloadLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
