using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderScript : MonoBehaviour {

    Transform player; //Object om de speler te volgen
    public GameObject Player; //public field om het player object in te stoppen
    float playerHeightY;//Hoogte die de border aanpast

    void Start () {
        player = Player.transform;
    }
	
	// Update is called once per frame
	void Update () {

        playerHeightY = player.position.y;
        float borderHeight = transform.position.y;
        float newBorderHeight = Mathf.Lerp(borderHeight, playerHeightY, Time.deltaTime * 10);
        if (playerHeightY > borderHeight)
        {
            //de nieuwe border positie is de huidige X, de nieuwe hoogte van de camera, de huidige Z
            transform.position = new Vector3(transform.position.x, newBorderHeight, transform.position.z);

        }
        else if (playerHeightY < borderHeight)
        {
            transform.position = new Vector3(transform.position.x, newBorderHeight, transform.position.z);
        }
    }
}
