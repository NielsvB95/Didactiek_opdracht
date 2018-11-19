using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{

    float platformSpeed = 2f; //plat speed
    bool endPoint; //endpoint for the platform
    GameObject Player; //gameobject for the player

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (endPoint)//if endpoint reached go to the right
        {
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        else //else go tto the left
        {
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        if(transform.position.x >= 3.25f) //end point on the rioghtside is reached
        {
            endPoint = false;
        }
        if(transform.position.x <= -3.25f) //end pint on the leftside is reached
        {
            endPoint = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        //make the player a child if it hits the platform. This will make it able to stay on the platform
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) 
    {
        //if it leaves the platform make it normal. This will make it able to leave the platform
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
        }
    }
}
