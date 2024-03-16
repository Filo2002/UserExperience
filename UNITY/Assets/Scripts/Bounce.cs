using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite base0, base1;

    // Start is called before the first frame update
    void Start()
    {
        if (SETTINGS.current_base == 0)
            spriteRenderer.sprite = base0;
        else
            spriteRenderer.sprite = base1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
        {

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.up * 600f);

        }

    }
}
