using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    private bool isStarted = false, boostInUse = false;

    public Text scoreText;
    public Text startText;

    public SpriteRenderer spriteRenderer;
    public Sprite player0, player1;

    public GameObject boostLevel, boost, textBoost;

    public GameObject player2obj1, player2obj2;

    float fill;

    // Start is called before the first frame update
    void Start()
    {
        boostLevel.transform.localScale = new Vector3(0,1,1);
        boost.SetActive(false);
        if (SETTINGS.current_skin == 0)
            spriteRenderer.sprite = player0;
        else
            spriteRenderer.sprite = player1;

        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

    }

     void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.G))
        {
            player2obj1.SetActive(true);
            player2obj2.SetActive(true);

        }


        if (rb2d.transform.position.y < SETTINGS.GetPoints(SETTINGS.isFirstPlayer) - 50)
        {
            if(SETTINGS.singleplayer)
                SceneManager.LoadScene("Finish");
            else if (SETTINGS.isFirstPlayer)
            {
                SETTINGS.isFirstPlayer = false;
                SceneManager.LoadScene("GameScene");
            }
            else
            {
                SceneManager.LoadScene("Finish");
            }
        }
        

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && isStarted == false)
        {

            isStarted = true;
            boost.SetActive(true);
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;

        }

        if (isStarted == true)
        {

            if (moveInput < 0)
            {

                this.GetComponent<SpriteRenderer>().flipX = SETTINGS.current_skin == (Skin)1;

            }
            else
            {

                this.GetComponent<SpriteRenderer>().flipX = SETTINGS.current_skin != (Skin)1;

            }

            bool isFirstPlayer = SETTINGS.isFirstPlayer;

            if((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) && fill > 0)
            {
                boostInUse = true;
            }

            if ( fill <= 0.02)
            {
                boostInUse = false;
            }

            //speed

            if (!boostInUse)
            {
                fill = (float)(fill + 0.00005) < 1 ? (float)(fill + 0.00005) : 1;
            }
            else
            {
                fill = (float)(fill - 0.0001) > 0 ? (float)(fill - 0.0001) : 0;
            }

            if (rb2d.velocity.y > 0 && transform.position.y > 0)
            {
                SETTINGS.SetPoints(isFirstPlayer, ((int)transform.position.y));
               
            }

            Debug.Log(boostInUse);

            textBoost.GetComponent<Text>().text = boostInUse ? "BOOST ON" : "PREMI W PER USARE IL BOOST";

            boostLevel.GetComponent<Image>().color = boostInUse ? Color.green : Color.red;
            rb2d.gravityScale = boostInUse ? 3.5f : 5f;


            boostLevel.transform.localScale = new Vector3(fill, 1, 1);


            if (SETTINGS.GetPoints(isFirstPlayer) > SETTINGS.GetRecord(isFirstPlayer))
                SETTINGS.SetRecord(isFirstPlayer, SETTINGS.GetPoints(isFirstPlayer));


            scoreText.text = "Punteggio " + SETTINGS.GetPlayerName(isFirstPlayer) + " : " + Mathf.Round(SETTINGS.GetPoints(isFirstPlayer)).ToString();
        }

    }

    void FixedUpdate()
    {

        if (isStarted == true)
        {

            moveInput = Input.GetAxis("Horizontal");
            Debug.Log(moveInput);
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"))
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), collision.collider, false);
        }
    }
}
