using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowAim : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;

    //Shoot variables
    private float arrowTimeInAir = 1f;
    public float timeBetweenShoot = 2f;
    public float timeShot;

    //Delete variables
    public float timeDelete;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("PlayerHitbox");
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting arrows
        if (timeShot <= Time.time && gameObject.name == "Arrow")
        {
            timeShot = Time.time + timeBetweenShoot;
            Shoot();
        }

        //Deleting arrows
        if (timeDelete <= Time.time && gameObject.name != "Arrow")
        {
            Destroy(gameObject);
        }
        
    }

    //Arrow track
    void SetRotation(GameObject arr)
    {
        Vector2 direction = arr.GetComponent<Rigidbody2D>().velocity;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        arr.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    //Aim
    Vector2 Aim(float t)
    {
        float x = -18.5f;
        float y = player.transform.position.y + 0.5f - transform.position.y;
        float vX = x / t;
        float vY = y / t;

        return new Vector2 (vX, vY);
    }

    //Cloning and giving direction to arrows
    void Shoot()
    {
        GameObject arrow = Instantiate(gameObject);
        arrow.name = "Arrow Clone";
        arrow.GetComponent<Rigidbody2D>().velocity = Aim(arrowTimeInAir);
        SetRotation(arrow);
        arrow.GetComponent<ArrowAim>().timeDelete = Time.time + arrowTimeInAir*2.5f;
    }
}
