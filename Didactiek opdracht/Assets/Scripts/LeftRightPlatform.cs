using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{

    float platformSpeed = 2f;
    bool endPoint;
    GameObject Player; 

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (endPoint)
        {
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        if(transform.position.x >= 3.25f)
        {
            endPoint = false;
        }
        if(transform.position.x <= -3.25f)
        {
            endPoint = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
        }
    }
}
