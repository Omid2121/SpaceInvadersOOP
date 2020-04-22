﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 30;

    private Rigidbody2D rigidBody;
    public Sprite explodedAlienImage;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.up * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Wall")
        {
            Destroy(gameObject);
        }

        if (col.tag =="Alien")
        {
            IncreaseTextUIScore();

            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            DestroyObject(col.gameObject, 0.5f);

            Destroy(gameObject);

           
        }

        if (col.tag == "Shield")
        {
            Destroy(gameObject);
            DestroyObject(col.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void IncreaseTextUIScore()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score += 10;

        textUIComp.text = score.ToString();

    }
}
