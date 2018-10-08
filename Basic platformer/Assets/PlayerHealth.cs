using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public bool Alive;

    private GameObject deathText;
    private GameObject collectableText;
    private int points;
    
    public Text setDeathText;

    // Use this for initialization
    void Start () {
        Alive = true;
        deathText = GameObject.FindWithTag("DeathPanel");
        collectableText = GameObject.FindWithTag("CollectablePanel");
        points = 0;

        deathText.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
            if (!Alive)
            {
                Time.timeScale = 0;
                GameObject Player = GameObject.FindWithTag("Player");
                CharacterController2D characterController = Player.GetComponent<CharacterController2D>();
                points = characterController.count;
                
                deathText.SetActive(true);
                setDeathText.text = "You are dead. \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Stars gotten: " + points.ToString() + "/3";
                collectableText.SetActive(false);
                if (Input.anyKey)
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Game");
                }
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