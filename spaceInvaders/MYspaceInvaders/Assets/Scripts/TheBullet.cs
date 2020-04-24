using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBullet : MonoBehaviour
{
    public float speed = 30;
    private Rigidbody2D rigidBody;
    public Sprite explodedAlienImage;

    void OnTriggerEnter2D(Collider2D col)
    {

    }


    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }



    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
