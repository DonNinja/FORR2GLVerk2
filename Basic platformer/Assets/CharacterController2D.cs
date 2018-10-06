using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
    public int playerSpeed = 10;
    private bool haegriSnu = true;
    public int playerJumpPower = 1250;
    private float moveHorizon;

    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        //CONTROLS
        moveHorizon = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            Stokk();
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
}