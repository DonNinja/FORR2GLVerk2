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
        winText = GameObject.FindWithTag("WinPanel"); //Finnur hlut með Tag "WinPanel"
        collectableText = GameObject.FindWithTag("CollectablePanel");
        points = 0;

        winText.SetActive(false); //Felur winText
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        CharacterController2D characterController = Player.GetComponent<CharacterController2D>(); //Nær í properties úr CharacterController2D

        if (Winner) //ef player vinnur
        {
            Time.timeScale = 0; //Stoppar öll movements í leiknum
            points = characterController.count; //finnur count í CharacterController2D

            winText.SetActive(true); //Sýnir winText
            if (points == 0)
            {
                setDeathText.text = "How did you get no stars? \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + points.ToString() + "/3";
            }
            else if (points == 1)
            {
                setDeathText.text = "You win, but not by much! \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + points.ToString() + "/3";
            }
            else if (points == 2)
            {
                setDeathText.text = "You win, only one more to get! \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + points.ToString() + "/3";
            }
            else if (points == 3)
            {
                setDeathText.text = "You win, got all the points! \n";
                setDeathText.text += "Press any key to start again. \n";
                setDeathText.text += "Points gotten: " + points.ToString() + "/3";
            }
            collectableText.SetActive(false);
            if (Input.anyKey) //Ef maður ýtir á einhvern takka þá runnar þetta
            {
                Time.timeScale = 1; //Byrjar að spila leikinn
                SceneManager.LoadScene("Game");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D deathzone) //Um leið og player lendir á/í Collision2D object þá callar það þetta
    {
        if (deathzone.gameObject.tag == "Finish") //Ef tagið á Collision object er "Finish"
        {
            Winner = true;
        }
    }
}
