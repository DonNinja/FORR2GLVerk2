using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public bool Alive;

	// Use this for initialization
	void Start () {
        Alive = true;
	}
	
	// Update is called once per frame
	void Update () {
            if (!Alive)
            {
                SceneManager.LoadScene("Game");
            }
        }

    private void OnTriggerEnter2D(Collider2D deathzone)
    {
        if (deathzone.tag == "Respawn")
        {
            Alive = false;
        }
    }
}