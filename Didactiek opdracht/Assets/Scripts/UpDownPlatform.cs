using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownPlatform : MonoBehaviour {

    //this code works the same as the left and right platform only it goes up and down
    float platformSpeed = 2f;
    float startPoint; //start point for the platform
    float endPoint; //end point for the platform
    bool position; //check position 
    public int unitsToMove = 2; //set the value of how far the platform can move
    GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //set the player object
        startPoint = transform.position.y; //set the startpoint
        endPoint = startPoint + unitsToMove; //set the endpoint
    }
    // Update is called once per frame
    void Update()
    {
        //if position is false move up
        if (position)
        {
            transform.position += Vector3.up * platformSpeed * Time.deltaTime;
        }
        //if position is false move down
        else
        {
            transform.position -= Vector3.up * platformSpeed * Time.deltaTime;
        }
        //set position false is the endpoint is reached
        if (transform.position.y >= endPoint)
        {
            position = false;
        }
        //set position to true if the startpoint is reached
        if (transform.position.y <= startPoint)
        {
            position = true;
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
        //if it leaves the platform maek it normal. This will make it able to leave the platform
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
        }
    }
}
