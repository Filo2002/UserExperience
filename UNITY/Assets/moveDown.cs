using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveDown : MonoBehaviour
{
    public Transform player;
    float posPlayerY;

    public GameObject c1, c2, c3;


    // Start is called before the first frame update
    void Start()
    {
        posPlayerY = player.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.GetComponent<Transform>().position;
        pos.y = (player.position.y - posPlayerY) / 5 + (pos.y - 0.02f);
        this.GetComponent<Transform>().SetPositionAndRotation(pos, this.GetComponent<Transform>().rotation);
        posPlayerY = player.position.y;

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            GetComponent<BoxCollider2D>().isTrigger = false;

            if (c3.active)
            {
                c3.SetActive(false);
            }
            else if (c2.active)
            {
                c2.SetActive(false);

            }
            else if (c1.active)
            {
                SceneManager.LoadScene("Finish");

            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }




}
