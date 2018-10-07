using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWins : MonoBehaviour
{
    public bool Winner;

    private GameObject winText;
    private GameObject collectableText;
    private int points;

    public Text setDeathText;

    // Use this for initialization
    void Start()
    {
        Winner = false;
        winText = GameObject.FindWithTag("WinPanel");
        collectableText = GameObject.FindWithTag("CollectablePanel");

        winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        CharacterController2D characterController = Player.GetComponent<CharacterController2D>();

        if (Winner)
        {
            Time.timeScale = 0;
            points = characterController.count;

            winText.SetActive(true);
            if (points == 0)
            {
                setDeathText.text = "How did you get no stars? \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + (points * 1000).ToString();
            }
            else if (points == 1)
            {
                setDeathText.text = "You win, but not by much! \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + (points * 1000).ToString();
            }
            else if (points == 2)
            {
                setDeathText.text = "You win, only one more to get! \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + (points * 1000).ToString();
            }
            else if (points == 3)
            {
                setDeathText.text = "You win, got all the points! \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + (points * 1000).ToString();
            }
            collectableText.SetActive(false);
            if (Input.anyKey)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Game");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D deathzone)
    {
        if (deathzone.gameObject.tag == "Finish")
        {
            Winner = true;
        }
    }
}
