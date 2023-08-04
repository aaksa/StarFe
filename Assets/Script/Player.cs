using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float moveSpeed = 15f;
    Rigidbody2D rb;
    AudioManager audioManager;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {

        //if (Input.GetMouseButton(0))
        //{
        //    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //    if (touchPos.x < 0)
        //    {
        //        rb.AddForce(Vector2.left * moveSpeed);
        //        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed), rb.velocity.y);
        //    }
        //    else
        //    {
        //        rb.AddForce(Vector2.right * moveSpeed);
        //        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -moveSpeed, moveSpeed), rb.velocity.y);
        //    }
        //}
        //else
        //{
        //    rb.velocity = new Vector2(0f, rb.velocity.y); // Stop the player's horizontal movement
        //}
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (touchPos.x < 0)
            {
                // Move the player to the left
                transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Move the player to the right
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Meteor")
        {
            audioManager.PlaySFX(audioManager.death);
            SceneManager.LoadScene(2);
        }
    }



}
