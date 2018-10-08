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
        moveHorizon = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            if (grounded == false)
            {

            }
            else
            {
                Stokk();
            }
        }
        //PLAYER ÁTT
        if (moveHorizon < 0.0f && haegriSnu == true)
        {
            PancakeFlip();
        }
        else if (moveHorizon > 0.0f && haegriSnu == false )
        {
            PancakeFlip();
        }
        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveHorizon * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Stokk()
    {
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
    }

    void PancakeFlip()
    {
        haegriSnu = !haegriSnu;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionExit2D(Collision2D platty)
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

    private void OnTriggerEnter2D(Collider2D collect)
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