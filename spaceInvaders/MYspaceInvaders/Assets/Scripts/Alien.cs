﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    public float secBeforeSpriteChange = 0.5f;
    public GameObject alienBullet;
    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 3.0f;
    public float baseFireWaitTime = 3.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = new Vector2(1, 0) * speed;
        spriteRenderer = GetComponent<SpriteRenderer>();

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

    }

    void Turn (int direction) //Turn in opposite direction
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }

    void MoveDown() //move down after hitting wall
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }

        if (col.gameObject.name == "RightWall")
        {
            Turn(-1);
            MoveDown();
        }

        if (col.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        if (Time.time > baseFireWaitTime)
        {
            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            DestroyObject(col.gameObject, 0.5f);
        }
    }

}
