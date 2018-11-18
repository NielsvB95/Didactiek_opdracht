using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour {

    public float jumpHight = 800f;// velocity added to the player
    float VelY;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // set the rigidbody for the jumpplatform
    }
    // Update is called once per frame
    void Update () {
        
        VelY = rb.velocity.y;
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        // add velocity if the player touches the platform
        if(col.tag == "Jumping" && VelY <= 0)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, jumpHight));
        }
    }
}
