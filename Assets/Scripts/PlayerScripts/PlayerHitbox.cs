using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    //Player game object
    private GameObject player;
    private bool isSliding;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        isSliding = player.GetComponent<PlayerMovement>().isSliding;

        //Attaching hitbox to player
        if (isSliding)
        {
            transform.localScale = new Vector2(2, 1);
            transform.position = new Vector2(-9.5f, player.transform.position.y - 0.5f);
        }
        else
        {
            transform.localScale = new Vector2(1, 2);
            transform.position = new Vector2(-10.5f, player.transform.position.y - 0.5f);
        }
    }


}
