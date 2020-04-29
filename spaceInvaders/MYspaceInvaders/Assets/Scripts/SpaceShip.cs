using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float speed = 30;

    public GameObject theBullet;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        float horzMove = Input.GetAxisRaw("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(horzMove, 0) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(theBullet, transform.position, Quaternion.identity);
        }
    }
}
