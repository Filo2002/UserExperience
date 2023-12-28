using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    private ScoreStorage scoreStorage = new ScoreStorage();
    private Rigidbody2D rb2d;
    private float moveInput;
    private float speed = 10f;

    private bool isStarted = false;

    public Text scoreText;
    public Text startText;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

        rb2d.gravityScale = 0;
        rb2d.velocity = Vector3.zero;

    }

     void Update()
    {
        if(rb2d.transform.position.y < scoreStorage.GetScore() - 50)
            SceneManager.LoadScene("Finish");

        if (Input.GetKeyDown(KeyCode.Space) && isStarted == false)
        {

            isStarted = true;
            startText.gameObject.SetActive(false);
            rb2d.gravityScale = 5f;

        }

        if (isStarted == true)
        {

            if (moveInput < 0)
            {

                this.GetComponent<SpriteRenderer>().flipX = false;

            }
            else
            {

                this.GetComponent<SpriteRenderer>().flipX = true;

            }

            if (rb2d.velocity.y > 0 && transform.position.y > scoreStorage.GetScore())
                scoreStorage.SetScore(transform.position.y);

            

            scoreText.text = "Punteggio: " + Mathf.Round(scoreStorage.GetScore()).ToString();
        }

    }

    void FixedUpdate()
    {

        if (isStarted == true)
        {

            moveInput = Input.GetAxis("Horizontal");
            rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        }

    }
}
