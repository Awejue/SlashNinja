using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Touch theTouch;
    public BoxCollider2D boxCollider;

    //Player position
    protected float playerX;
    protected float playerY;

    //Touch variables
    private float startY;
    private float endY;
    private float endX;

    //Maximum Y player can reach
    private float maxY = 3f;

    //Slide variables
    private float timeForSlide = 1f;
    private float timeSlide;

    //Slide and jump bools
    public bool isSliding = false;
    public bool isOnFloor = false;

    //Attack variables
    public bool isAttacking = false;
    public float timeAttacking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //Start collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.Equals(GameObject.Find("Floor")))
            isOnFloor = true;
    }

    //End collision
    private void OnCollisionExit2D(Collision2D collision)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Player position updating
        playerY = transform.position.y;

        //Max player Y
        if (transform.position.y > maxY)
        {
            transform.position = new Vector2(transform.position.x, maxY);
            rb.velocity = new Vector2(0, 0);
        }

        //Slide time
        if (isSliding && timeSlide <= Time.time)
        {
            transform.localScale = new Vector2(2,3);
            isSliding = false;
        }

        //Touch and movement
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);

            //Touch start
            if (theTouch.phase == TouchPhase.Began)
            {
                startY = theTouch.position.y;
            }

            //Touch end ; Finger slide
            if (theTouch.phase == TouchPhase.Ended)
            {
                endY = theTouch.position.y;
                endX = theTouch.position.x;

                //Jump
                if (startY < endY && isOnFloor)
                {
                    rb.velocity = new Vector2(0, 30);
                    transform.localScale = new Vector2(2, 3);
                    isSliding = false;
                    isOnFloor = false;
                }
                
                //Slide
                else if (startY > endY)
                {
                    rb.velocity = new Vector2(0, -30);
                    transform.localScale = new Vector2(3, 2);
                    isSliding = true;
                    timeSlide = Time.time + timeForSlide;
                }

                //Attack
                else if (endX > Screen.width/2)
                {
                    
                }
                //Block
                else if(endX <= Screen.height / 2)
                {

                }
            }


        }
    }
}
