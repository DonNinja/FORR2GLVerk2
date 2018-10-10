using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
    private bool haegriSnu = true;
    private bool grounded;
    public int playerJumpPower = 1250;
    public int playerSpeed = 10;
    public int count;
    private float moveHorizon;
    private GameObject collectableText;

    public Text collectCountText;

    private void Start()
    {
        count = 0;
    }

    void Update()
    {
        PlayerMove();

        CollectableCount();
    }

    void PlayerMove()
    {
        //CONTROLS
        moveHorizon = Input.GetAxis("Horizontal"); //fær Input á Horizontal í Input Manager
        if (Input.GetButtonDown("Jump")) 
        {
            if (grounded == false) //Stekkur ekki ef player er í loftinu
            {

            }
            else
            {
                Stokk();
            }
        }
        //PLAYER ÁTT
        if (moveHorizon < 0.0f && haegriSnu == true) //Ef player færir sig til vinstri og hann snýr til hægri
        {
            PancakeFlip();
        }
        else if (moveHorizon > 0.0f && haegriSnu == false) //Ef player færir sig til hægri og hann snýr til vinstri
        {
            PancakeFlip();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizon * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); 
    }

    void Stokk()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower); //Skellir force á player til að fá hann til að stökkva
    }

    void PancakeFlip()
    {
        haegriSnu = !haegriSnu; //setur haegrisnu til að vera öfugt bool
        Vector2 localScale = gameObject.transform.localScale; //tekur inn localScale á gameObject
        localScale.x *= -1; //snýr localscale við
        transform.localScale = localScale; //breytir character localscale í localscale
    }

    private void OnCollisionExit2D(Collision2D platty) //Þegar collision hættir við platty
    {
        if (platty.gameObject.tag == "Platform" || platty.gameObject.tag == "Lift")
        {
            grounded = false;
        }
        if (platty.transform.tag == "Lift")
        {
            transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D platty)
    {
        if (platty.gameObject.tag == "Platform" || platty.gameObject.tag == "Lift")
        {
            grounded = true;
        }
        if (platty.transform.tag == "Lift")
        {
            transform.parent = platty.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collect) //Þegar maður lendir á trigger collider
    {
        if (collect.gameObject.tag == "Collectable")
        {
            collect.gameObject.SetActive(false);

            count = count + 1;

            CollectableCount();
        }
    }

    void CollectableCount()
    {
        collectCountText.text = "Score: " + count.ToString() + "/3";
    }
}