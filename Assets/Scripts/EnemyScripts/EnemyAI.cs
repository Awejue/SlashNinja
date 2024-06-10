using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject arrow;
    public Rigidbody2D arrowRB;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = GameObject.Find("Arrow");
        arrowRB = arrow.GetComponent<Rigidbody2D>();
        arrowRB.centerOfMass = new Vector2(-10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {
        
    }
}
