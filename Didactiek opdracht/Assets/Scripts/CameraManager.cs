using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    Transform player; //Object om de speler te volgen
    public GameObject Player; //public field om het player object in te stoppen
    float playerHeightY;//Hoogte die de camera aanpast

    public Transform regular; //Sla de Platform Prefabs op
    public Transform jump;
    public Transform leftRight;
    public Transform UpDown;
    public Transform Question;  // Einde van opslaan

    private int platNumber;

    private float platCheck;
    private float spawnPlatformsTo;


    // Use this for initialization
    void Start()
    {
        player = Player.transform;

        PlatformSpawner(10f, false);
    }

    // Update is called once per frame
    void Update()
    {
        //follow current Y value.
        playerHeightY = player.position.y;

        if (playerHeightY > platCheck)
        {
            PlatformManager();
        }
        //follow current camera Y value.
        float currentCameraHeight = transform.position.y;
        // Change the height of the camera
        float newHeightOfCamera = Mathf.Lerp(currentCameraHeight, playerHeightY, Time.deltaTime * 10);
        // Change the height of the camera if the height of the player is higher than the camera
        if (playerHeightY > currentCameraHeight)
        {
            //the new camera position is the current X, new height of the camera, current Z
            transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);

        } else if (playerHeightY < currentCameraHeight - 1) // if the player fals down follow the player with the camera
        {
            transform.position = new Vector3(transform.position.x, newHeightOfCamera, transform.position.z);
        }

        OnGui2D.score = (int)Time.timeSinceLevelLoad; // set the score counter

    }

    void PlatformManager()
    {
        //check for next platforms it will spawn if the height is 15 higher
        platCheck = player.position.y + 15;

        PlatformSpawner(platCheck + 15, false);//bool is for the check to spawn a question
    }

    void PlatformSpawner(float floatValue, bool question)
    {
        float y = spawnPlatformsTo; //Y value where the platform will spawn

        while (y <= floatValue)
        {
            float x = Random.Range(-3.25f, 3.25f); //X range where the platforms will spawn

            platNumber = Random.Range(1, 5); // platnumbers which are leftright, regular etc

            Vector2 posXY = new Vector2(x, y); //position for the platform
            if (posXY.y % 10 == 0) //every 10 heigt spawn a question
            {
                platNumber = 5; //set platnumber to 5
            }
            switch (platNumber) //switch to randomise the platforms
            {
                case 1:
                    Instantiate(regular, posXY, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(jump, posXY, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(leftRight, posXY, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(UpDown, posXY, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(Question, posXY, Quaternion.identity);
                    break;
            }
            y += 2f; //set the y + 2 for the next platform
        }
        spawnPlatformsTo = floatValue; //set the y value for the next platform.
    }
}
