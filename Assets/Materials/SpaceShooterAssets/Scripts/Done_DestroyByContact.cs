using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Done_DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") {
            return; 
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            Done_GameController.instance.GameOver();
        }
        Done_GameController.instance.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
